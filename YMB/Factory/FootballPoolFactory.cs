using System;
using System.Collections.Generic;
using System.Linq;
using YMB.Models;
using YMB.Factory;
using YMB.Extensions;
using YMB.Controllers;
using YMB.Utility;

namespace YMB.Factory
{
    public class FootballPoolFactory
    {

        private const string FOOTBALL_ROLE = "FootballPool";
        

        internal static void RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            ApplicationUser thisUser = GetFootballPoolUser(userId, _db);
            //add role 3 to userName
            _db = UtilFactory.AddUserToRole(userId, FOOTBALL_ROLE, _db);
            _db.SaveChanges();
            //flip flag on users entry
            _db = SetUserPlayingFootballPool(userId, _db);
            _db.SaveChanges();
            //add user to football users table
            _db = AddFootballUser(simpleUserId, userName, thisUser, _db);
            _db.SaveChanges();
            _db.Dispose();
        }

        internal static FootballPoolViewModel BuildFootballPoolViewModel(int weekId, int simpleUserId)
        {
            FootballPoolViewModel footballPoolViewModel = new FootballPoolViewModel() { footballGames = GetWeeklyGames(weekId), userPicks = GetUsersPicks(weekId, simpleUserId), byeWeekTeams = GetByeWeekTeams(weekId) };
            return footballPoolViewModel;
        }

        private static IEnumerable<ByeWeekTeam> GetByeWeekTeams(int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<ByeWeekTeam> teamsOnBye = new List<ByeWeekTeam>();
            List<int> allFootballTeamIds = _db.FootballTeam.Select(ft => ft.teamId).ToList();
            List<int> allFootballTeamsPlayingIds = _db.FootballGame.Where(fg => fg.weekId == weekId).Select(fg => new[] { fg.homeTeam.teamId, fg.awayTeam.teamId } ).SelectMany(fg => fg).ToList();
            List<int> allFootballTeamsNotPlayingIds = new List<int>();
            allFootballTeamsNotPlayingIds = allFootballTeamIds.Except(allFootballTeamsPlayingIds).ToList();

            foreach (var id in allFootballTeamsNotPlayingIds)
            {
                string teamName = _db.FootballTeam.Where(ft => ft.teamId == id).Select(ft => ft.teamName).First().ToString();
                string imageUrl = _db.FootballTeam.Where(ft => ft.teamId == id).Select(ft => ft.imageURL).First().ToString();
                ByeWeekTeam team = new ByeWeekTeam() { teamId = id, teamName = teamName, imageURL = imageUrl };
                teamsOnBye.Add(team);
            }

            return teamsOnBye;
        }

        internal static void SubmitPicks(Dictionary<string, string> picks, int simpleUserId, int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolUserPicks userPick;
            foreach (var pick in picks)
            {
                userPick = new FootballPoolUserPicks() { gameId = Convert.ToInt32(pick.Key), weekId = weekId, simpleUserId = simpleUserId, pick = Convert.ToInt32(pick.Value) };
                if (_db.FootballPoolUserPicks.Any(p => p.simpleUserId == userPick.simpleUserId && p.gameId == userPick.gameId))
                {
                    //update
                    FootballPoolUserPicks existingUserPick = _db.FootballPoolUserPicks.Where(p => p.simpleUserId == userPick.simpleUserId && p.gameId == userPick.gameId).First();
                    LoggerFactory.LogInfo("Updating pick", "Week: " + weekId, string.Format("From pick: {0} to pick: {1}", existingUserPick.pick, userPick.pick), Convert.ToString(simpleUserId));
                    existingUserPick.pick = userPick.pick;
                    _db.Entry(existingUserPick).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    //add
                    LoggerFactory.LogInfo("Adding pick", "Week: " + weekId, "User pick: " + userPick.pick, Convert.ToString(simpleUserId));
                    _db.FootballPoolUserPicks.Add(userPick);
                }

            }
            _db.SaveChanges();
        }

        internal static void SubmitGameScores(FootballPoolViewModel thisVW)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            foreach (var game in thisVW.footballGames)
            {
                FootballGame thisGame = _db.FootballGame.Where(g => g.gameId == game.gameId).FirstOrDefault();
                thisGame.awayTeamScore = game.awayTeamScore;
                thisGame.homeTeamScore = game.homeTeamScore;
                //determine winning column
                thisGame = SetWinningAndLossingTeams(thisGame);
                _db.Entry(thisGame).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// This method will update each team's win/loss, win % and points for/against
        /// </summary>
        internal static void UpdateTeamInfo()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<FootballTeam> teams = _db.FootballTeam.ToList();
            
            
            foreach (var team in teams)
            {
                var totalGamesPlayed = _db.FootballGame.Where(g => g.winningTeamId != 0 && g.lossingTeamId != 0 && (g.awayTeam.id == team.teamId || g.homeTeam.id == team.id)).Count();
                team.win = _db.FootballGame.Where(g => g.winningTeamId != 0 && g.winningTeamId == team.teamId).Select(g => g.winningTeamId).Count();
                team.loss = _db.FootballGame.Where(g => g.lossingTeamId != 0 && g.lossingTeamId == team.teamId).Select(g => g.lossingTeamId).Count();
                team.tie = _db.FootballGame.Where(g => g.lossingTeamId == -1 && g.winningTeamId == -1 && (g.awayTeam.id == team.teamId || g.homeTeam.id == team.id)).Count();
                var winPercentage = 0.00M;
                if (team.loss > 0)
                {
                    winPercentage = Math.Round((Convert.ToDecimal(team.win) / Convert.ToDecimal(totalGamesPlayed)) * 100.00M, 2);
                }
                else
                {
                    winPercentage = 100.00M;
                }
                team.winPercentage = winPercentage;
                _db.Entry(team).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }

        }

        private static FootballGame SetWinningAndLossingTeams(FootballGame thisGame)
        {
            var awayScore = thisGame.awayTeamScore;
            var homeScore = thisGame.homeTeamScore;
            if (awayScore != null && homeScore != null)
            {

                if (awayScore > homeScore)//away team wins
                {
                    thisGame.winningTeamId = thisGame.awayTeam.teamId;
                    thisGame.lossingTeamId = thisGame.homeTeam.teamId;
                }
                else if (homeScore > awayScore)//home team wins
                {
                    thisGame.winningTeamId = thisGame.homeTeam.teamId;
                    thisGame.lossingTeamId = thisGame.awayTeam.teamId;
                }

                if (awayScore == homeScore)
                {
                    thisGame.winningTeamId = -1; //tie
                    thisGame.lossingTeamId = -1;
                }
            }
            return thisGame;
        }

        private static List<FootballPoolUserPicks> GetUsersPicks(int weekId, int simpleUserId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<FootballPoolUserPicks> userPicks = _db.FootballPoolUserPicks.Where(p => p.weekId == weekId && p.simpleUserId == simpleUserId).ToList();
            return userPicks;
        }

        private static ApplicationUser GetFootballPoolUser(string userId, ApplicationDbContext db)
        {

            ApplicationUser thisUser = db.Users.Where(a => a.Id == userId).First<ApplicationUser>();
            return thisUser;
        }

        private static List<FootballGame> GetWeeklyGames(int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<FootballGame> gamesThisWeek = _db.FootballGame.Where(g => g.weekId == weekId).ToList();
            return gamesThisWeek;
        }

        private static ApplicationDbContext SetUserPlayingFootballPool(string userId, ApplicationDbContext db)
        {
            ApplicationUser thisUser = db.Users.Where(a => a.Id == userId).First<ApplicationUser>();
            thisUser.isPlayingFootballPool = true;
            db.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
            return db;
        }

        private static ApplicationDbContext AddFootballUser(int simpleUserId, string userName, ApplicationUser thisUser, ApplicationDbContext db)
        {
            FootballPoolUsers thisFootballUser = new FootballPoolUsers() { simpleUserId = simpleUserId, userName = userName, signedUpDate = DateTime.Now, hasPaid = false};
            var userExistsAlready = db.FootballPoolUser.Where(u => u.simpleUserId == simpleUserId).FirstOrDefault();
            if (userExistsAlready == null)
            {
                try
                {
                    LoggerFactory.LogInfo("AddFootballUser", "Attempting to add football user", "Username: " + userName, Convert.ToString(simpleUserId));
                    db.FootballPoolUser.Add(thisFootballUser);
                    LoggerFactory.LogInfo("AddFootballUser", "Successfully added football user.", "Username: " + userName, Convert.ToString(simpleUserId));
                    //db.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerFactory.LogError("AddFootballUser", "Attempting to add football user failed: " + string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, Convert.ToString(simpleUserId));
                }
            }
            return db;
        }



        internal static FootballPoolViewModel GetLeaderboard()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolViewModel vw = new FootballPoolViewModel() { users = _db.FootballPoolUser.ToList().OrderByDescending(m => m.userScore) };
            return vw;
        }

        internal static void GenerateUserScores(int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            var simpleUserIdList = _db.Users.Where(u => u.isPlayingFootballPool == true).Select(u => u.simpleUserId).ToList();
            var winningTeamsIdList = _db.FootballGame.Where(fg => fg.weekId == weekId).Select(fg => fg.winningTeamId).ToList();
            var numOfGamesThisWeek = _db.FootballGame.Where(g => g.weekId == weekId).ToList().Count;

            foreach (var userId in simpleUserIdList)
            {
                decimal userScoreThisWeek = 0.00M;
                decimal bonusPointsThisWeek = 0.00M;
                var lossesThisWeek = 0;
                var winsThisWeek = 0;
                FootballPoolUsers thisUser = _db.FootballPoolUser.Where(u => u.simpleUserId == userId).First();
                var thisUsersPicks = _db.FootballPoolUserPicks.OrderBy(up => up.gameId).Where(up => up.simpleUserId == userId && up.weekId == weekId).Select(up => up.pick).ToList();
                //var thisUsersPicks = _db.FootballPoolUserPicks.Where(up => up.simpleUserId == userId && up.weekId == weekId).Select(up => up.pick).ToList();
                var gamesScored = _db.FootballGame.Where(fg => fg.winningTeamId != 0 && fg.lossingTeamId != 0 && fg.weekId == weekId).ToList().Count();
                if (thisUsersPicks.Count > 0)
                {
                    //need to compare user list to the winning list
                    for (int i = 0; i < numOfGamesThisWeek; i++)
                    {
                        if (winningTeamsIdList[i] != 0)//game has been scored - winning Id = 0 means game has not been scored so it should not count towards user score generation
                        {
                            if (thisUsersPicks[i] == winningTeamsIdList[i])
                            {
                                userScoreThisWeek += 1.00M;
                                winsThisWeek += 1;
                            }
                            else
                            {
                                lossesThisWeek += 1;
                            }
                        }
                        
                    }

                    bonusPointsThisWeek = Math.Floor(userScoreThisWeek / 5.00M);
                    bonusPointsThisWeek = (bonusPointsThisWeek * 0.25M);

                }
                else
                {
                    //user did not make their picks at all or at least what has been scored. find out how many games have been scored?
                    lossesThisWeek = gamesScored;
                }
                //Add to weekly score table
                FootballPoolUserWeeklyScores userWeeklyScoreObj = _db.FootballPoolUserWeeklyScores.Where(up => up.weekId == weekId && up.simpleUserId == userId).FirstOrDefault();
                if (userWeeklyScoreObj == null)
                {
                    //doesn't exsist so add it
                    FootballPoolUserWeeklyScores weeklyScore = new FootballPoolUserWeeklyScores() { score = userScoreThisWeek + bonusPointsThisWeek, simpleUserId = userId, weekId = weekId, wins = winsThisWeek, losses = lossesThisWeek };
                    _db.FootballPoolUserWeeklyScores.Add(weeklyScore);
                    _db.SaveChanges();
                }
                else
                {
                    //exsists so update the score record
                    userWeeklyScoreObj.wins = winsThisWeek;
                    userWeeklyScoreObj.losses = lossesThisWeek;
                    userWeeklyScoreObj.score = userScoreThisWeek + bonusPointsThisWeek;
                    _db.Entry(userWeeklyScoreObj).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }


                //update user table with score, represents all weeks
                thisUser.userScore = _db.FootballPoolUserWeeklyScores.Where(us => us.simpleUserId == userId).Select(up => up.score).Sum();

                //determine wins
                thisUser.win = _db.FootballPoolUserWeeklyScores.Where(us => us.simpleUserId == userId).Select(up => up.wins).Sum();

                //determine losses 
                thisUser.loss = _db.FootballPoolUserWeeklyScores.Where(us => us.simpleUserId == userId).Select(up => up.losses).Sum();


                _db.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        internal static FootballPoolViewModel BuildAccountProfileViewModel(int simpleUserId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolViewModel vw = new FootballPoolViewModel();
            List<FootballPoolUsers> thisUser = _db.FootballPoolUser.Where(u => u.simpleUserId == simpleUserId).ToList();
            vw.users = thisUser;
            return vw;
        }

        internal static FootballPoolViewModel CheckUserPicks(int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();

            var userIdList = _db.FootballPoolUser.Select(fp => fp.simpleUserId).ToList();
            var usersPicksMade = _db.FootballPoolUserPicks.Where(fp => fp.weekId == weekId).Select(fp => fp.simpleUserId).Distinct().ToList();
            var usersPicksNotMade = userIdList.Except(usersPicksMade).ToList();
            FootballPoolViewModel vw = new FootballPoolViewModel();

            List<FootballGame> gamesThisWeek = _db.FootballGame.Where(fg => fg.weekId == weekId).ToList();
            vw.footballGames = gamesThisWeek;

            List<FootballPoolUsers> users = _db.FootballPoolUser.ToList();
            vw.users = users;

            List<CheckUserPicks> userPickChecks = new List<CheckUserPicks>();

            foreach (var user in users)
            {
               CheckUserPicks thisUserCheck = new CheckUserPicks() { simpleUserId = user.simpleUserId, weekId = weekId, userName = user.userName };
               thisUserCheck.hasMadePicks = usersPicksNotMade.Contains(user.simpleUserId) ?  false :  true;
               thisUserCheck.numberOfPicksMade = _db.FootballPoolUserPicks.Where(fp => fp.weekId == weekId && fp.simpleUserId == user.simpleUserId && fp.pick != 0).Count();
               userPickChecks.Add(thisUserCheck);
            }

            vw.userPicksCheck = userPickChecks.OrderBy(up => up.hasMadePicks);

            return vw;
        }

        internal static List<ApplicationUser> GenerateUserListThatHaveNotMadePicksThisWeek(int weekId, int nextGameTimeId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            var userIdList = _db.FootballPoolUser.Select(fp => fp.simpleUserId).ToList();
            var usersPicksMade = _db.FootballPoolUserPicks.Where(fp => fp.weekId == weekId && fp.pick != 0 && fp.gameId == nextGameTimeId).Select(fp => fp.simpleUserId).Distinct().ToList();
            var usersPicksNotMade = userIdList.Except(usersPicksMade).ToList();
            List<ApplicationUser> userList = _db.Users.Join(usersPicksNotMade, u => u.simpleUserId, id => id, (u, id) => u).ToList();
            return userList;
        }

        internal static int GetNextGameTimeId(int weekId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            DateTime dateNow = CustomDateFunctions.GetDateTime();
            var nextFootballGameId = _db.FootballGame.OrderBy(fg => fg.gameDate).Where(fg => fg.gameDate > dateNow && fg.weekId == weekId).Select(fg => fg.gameId).First();
            return nextFootballGameId;
        }

        internal static DateTime GetGameTime(int gameId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            return _db.FootballGame.Where(fg => fg.gameId == gameId).Select(fg => fg.gameDate).First();
        }

        internal static FootballPoolViewModel CheckEntryFees()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolViewModel vw = new FootballPoolViewModel();

            vw.users = _db.FootballPoolUser.ToList();

            return vw;
        }

        internal static void UpdateEntryFeeFlag(int simpleUserId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolUsers thisUser = _db.FootballPoolUser.Where(u => u.simpleUserId == simpleUserId).First();
            thisUser.hasPaid = true;
            _db.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static FootballPoolViewModel GetUserAlerts(int simpleUserId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            FootballPoolViewModel vw = new FootballPoolViewModel() { alerts = _db.UserAlerts.Where(a => a.simpleUserId == simpleUserId).ToList() };
            return vw;
        }

        internal static List<ApplicationUser> GetUserListFromIds(List<int> simpleUserIds)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<ApplicationUser> userList = _db.Users.Where(u => simpleUserIds.Contains(u.simpleUserId)).ToList();
            return userList;
        }

        internal static List<ApplicationUser> GetAllUsers()
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            List<ApplicationUser> userList = _db.Users.ToList();
            return userList;
        }

        internal static void AddAlert(int simpleUserId, string alertTitle, string alertText, Boolean userCanDelete)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            UserAlerts newAlert = new UserAlerts() { alertRead = false, alertText = alertText, alertTitle = alertTitle, simpleUserId = simpleUserId, alertActive = true, alertDate = DateTime.Now, userCanDelete = userCanDelete };
            _db.UserAlerts.Add(newAlert);
            _db.SaveChanges();
        }

        internal static void UpdateAlertReadFlag(int alertId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            UserAlerts thisAlert = _db.UserAlerts.Where(a => a.id == alertId).First();
            thisAlert.alertRead = true;
            _db.Entry(thisAlert).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        internal static void DeleteAlert(int alertId)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            UserAlerts thisAlert = _db.UserAlerts.Where(a => a.id == alertId).First();
            thisAlert.alertActive = false;
            _db.Entry(thisAlert).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}