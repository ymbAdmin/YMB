using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YMB.Models;

namespace YMB.Factory
{
    public class FootballPoolFactory
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();
        private const string FOOTBALL_ROLE = "FootballPool";

        internal static void RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            //add role 3 to userName
            AddUserToRole(userId, FOOTBALL_ROLE);
            //flip flag on users entry
            ApplicationUser thisUser = SetUserPlayingFootballPool(userId);
            //add user to football users table
            AddFootballUser(simpleUserId, userName, thisUser);

        }

        private static ApplicationUser SetUserPlayingFootballPool(string userId)
        {
            ApplicationUser thisUser = _db.Users.Where(a => a.Id == userId).First<ApplicationUser>();
            thisUser.isPlayingFootballPool = true;
            _db.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return thisUser;
        }

        private static void AddFootballUser(int simpleUserId, string userName, ApplicationUser thisUser)
        {
            FootballPoolUsers thisFootballUser = new FootballPoolUsers() { simpleUserId = simpleUserId, userName = userName, userId = thisUser };
            _db.FootballPoolUser.Add(thisFootballUser);
            _db.SaveChanges();
        }

        internal static void AddUserToRole(string userId, string roleName)
        {
            var store = new UserStore<ApplicationUser>(_db);
            var manager = new UserManager<ApplicationUser>(store);
            manager.AddToRole(userId, roleName);
        }




        internal static FootballPoolViewModel GetWeeklyFootballBallSchedule(int weekId)
        {
            FootballPoolViewModel footballPoolViewModel = new FootballPoolViewModel();
            List<FootballGame> gamesThisWeek = _db.FootballGame.Where(g => g.weekId == weekId).ToList();
            footballPoolViewModel.footballGames = gamesThisWeek;


            return footballPoolViewModel;
        }
    }
}