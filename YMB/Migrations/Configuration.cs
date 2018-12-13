namespace YMB.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YMB.Models;
    using YMB.Models.GreenChamberApp;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the lhttp://localhost/YMB/Service References/atest version.

            if (true)
            {
                //SeedTeamData(context);
                //SeedGameData(context);
                //SeedUserPickData(context, 3);
                //ResetFootballTables(context);
                //ResetCompanyTables(context);
                SeedCompanyData(context);
            }
        }

        private void ResetFootballTables(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE FootballPoolUserPicks");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE FootballPoolUserWeeklyScores");
            context.Database.ExecuteSqlCommand("UPDATE FootballGames set homeTeamScore = NULL, awayTeamScore = NULL, winningTeamId = 0, lossingTeamId = 0");
            context.Database.ExecuteSqlCommand("UPDATE FootballPoolUsers set userScore = 0.00, win = 0, loss = 0");
        }

        private void ResetCompanyTables(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DROP TABLE CompanyServices");
            context.Database.ExecuteSqlCommand("DROP TABLE CompanyServices WHERE 1=1");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Companies");
        }
        private void SeedUserPickData(ApplicationDbContext context, int simpleUserId)
        {
            context.Database.ExecuteSqlCommand("truncate table dbo.FootballPoolUserPicks;");
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 1, pick = 13, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 2, pick = 19, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 3, pick = 9, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 4, pick = 11, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 5, pick = 28, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 6, pick = 10, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 7, pick = 1, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 8, pick = 14, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 9, pick = 6, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 10, pick = 25, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 11, pick = 31, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 12, pick = 17, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 13, pick = 12, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 14, pick = 29, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 15, pick = 18, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 16, pick = 30, simpleUserId = simpleUserId, weekId = 1 });

        }
        private void SeedGameData(ApplicationDbContext context)
        {
            //week 15
            context.FootballGame.Add(new FootballGame() { gameId = 209, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 31), awayTeam = context.FootballTeam.Single(f => f.teamId == 32), gameDate = new DateTime(2016, 12, 15, 20, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 210, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 1), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), gameDate = new DateTime(2016, 12, 17, 20, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 211, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 2), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 212, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 20), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 213, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 6), awayTeam = context.FootballTeam.Single(f => f.teamId == 19), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 214, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 5), awayTeam = context.FootballTeam.Single(f => f.teamId == 7), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 215, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 23), awayTeam = context.FootballTeam.Single(f => f.teamId == 12), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 216, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 24), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 217, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 14), awayTeam = context.FootballTeam.Single(f => f.teamId == 9), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 218, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 10), gameDate = new DateTime(2016, 12, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 219, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 28), gameDate = new DateTime(2016, 12, 18, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 220, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 25), awayTeam = context.FootballTeam.Single(f => f.teamId == 30), gameDate = new DateTime(2016, 12, 18, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 221, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 3), gameDate = new DateTime(2016, 12, 18, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 222, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 15), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), gameDate = new DateTime(2016, 12, 18, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 223, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 17), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), gameDate = new DateTime(2016, 12, 18, 20, 30, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 224, weekId = 15, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 26), gameDate = new DateTime(2016, 12, 19, 20, 30, 0) });
            //week 16
            context.FootballGame.Add(new FootballGame() { gameId = 225, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 19), awayTeam = context.FootballTeam.Single(f => f.teamId == 20), gameDate = new DateTime(2016, 12, 22, 20, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 226, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 26), awayTeam = context.FootballTeam.Single(f => f.teamId == 25), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 227, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 28), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 228, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 2), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 229, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 24), awayTeam = context.FootballTeam.Single(f => f.teamId == 18), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 230, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 3), awayTeam = context.FootballTeam.Single(f => f.teamId == 1), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 231, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 8), awayTeam = context.FootballTeam.Single(f => f.teamId == 15), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 232, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 10), awayTeam = context.FootballTeam.Single(f => f.teamId == 9), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 233, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 21), awayTeam = context.FootballTeam.Single(f => f.teamId == 23), gameDate = new DateTime(2016, 12, 24, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 234, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 16), awayTeam = context.FootballTeam.Single(f => f.teamId == 12), gameDate = new DateTime(2016, 12, 24, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 235, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 32), awayTeam = context.FootballTeam.Single(f => f.teamId == 30), gameDate = new DateTime(2016, 12, 24, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 236, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 31), awayTeam = context.FootballTeam.Single(f => f.teamId == 29), gameDate = new DateTime(2016, 12, 24, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 237, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 5), gameDate = new DateTime(2016, 12, 24, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 238, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 7), awayTeam = context.FootballTeam.Single(f => f.teamId == 6), gameDate = new DateTime(2016, 12, 25, 16, 30, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 239, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 14), awayTeam = context.FootballTeam.Single(f => f.teamId == 13), gameDate = new DateTime(2016, 12, 25, 20, 30, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 240, weekId = 16, homeTeam = context.FootballTeam.Single(f => f.teamId == 17), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), gameDate = new DateTime(2016, 12, 26, 20, 30, 0) });

            //week 17
            context.FootballGame.Add(new FootballGame() { gameId = 241, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 4), awayTeam = context.FootballTeam.Single(f => f.teamId == 3), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 242, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 12), awayTeam = context.FootballTeam.Single(f => f.teamId == 10), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 243, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 27), awayTeam = context.FootballTeam.Single(f => f.teamId == 26), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 244, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 23), awayTeam = context.FootballTeam.Single(f => f.teamId == 24), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 245, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 7), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 246, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 25), awayTeam = context.FootballTeam.Single(f => f.teamId == 28), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 247, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 1), awayTeam = context.FootballTeam.Single(f => f.teamId == 2), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 248, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 19), awayTeam = context.FootballTeam.Single(f => f.teamId == 17), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 249, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 22), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 250, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 9), awayTeam = context.FootballTeam.Single(f => f.teamId == 11), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 251, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 20), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 252, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 5), awayTeam = context.FootballTeam.Single(f => f.teamId == 6), gameDate = new DateTime(2017, 01, 1, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 253, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 15), awayTeam = context.FootballTeam.Single(f => f.teamId == 14), gameDate = new DateTime(2017, 01, 1, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 254, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), gameDate = new DateTime(2017, 01, 1, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 255, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 30), awayTeam = context.FootballTeam.Single(f => f.teamId == 31), gameDate = new DateTime(2017, 01, 1, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 256, weekId = 17, homeTeam = context.FootballTeam.Single(f => f.teamId == 32), awayTeam = context.FootballTeam.Single(f => f.teamId == 29), gameDate = new DateTime(2017, 01, 1, 16, 25, 0) });
        }

        private void SeedTeamData(ApplicationDbContext context)
        {
            context.FootballTeam.Add(new FootballTeam() { teamId = 1, teamName = "New York Jets", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 2, teamName = "Buffalo Bills", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 3, teamName = "New England Patriots", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 4, teamName = "Miami Dolphins", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 5, teamName = "Cincinnati Bengals", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 6, teamName = "Baltimore Ravens", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 7, teamName = "Pittsburg Steelers", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 8, teamName = "Cleveland Browns", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 9, teamName = "Tennessee Titans", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 10, teamName = "Jacksonville Jaguards", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 11, teamName = "Houston Texans", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 12, teamName = "Indianapolis Colts", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 13, teamName = "Denver Broncos", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 14, teamName = "Kansas City Chiefs", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 15, teamName = "San Diego Chargers", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 16, teamName = "Oakland Raiders", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 17, teamName = "Dallas Cowboys", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 18, teamName = "Washington Redskins", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 19, teamName = "Philadelphia Eagles", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 20, teamName = "New York Giants", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 21, teamName = "Green Bay Packers", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 22, teamName = "Detroit Lions", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 23, teamName = "Minnesota Vikings", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 24, teamName = "Chicago Bears", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 25, teamName = "Atlanta Falcons", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 26, teamName = "Carolina Panthers", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 27, teamName = "Tampa Bay Buccaneers", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 28, teamName = "New Orleans Saints", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 29, teamName = "Arizona Cardinals", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 30, teamName = "San Francisco 49ers", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 31, teamName = "Seattle Seahawks", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamId = 32, teamName = "Los Angeles Rams", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
        }

        private void SeedCompanyData(ApplicationDbContext context)
        {
            context.Companies.Add(new Company() { Id = 1, Name = "Joe's Donuts", StreetNumber = 1036, StreetName = "Hubbard St", City= "Jacksonville", State = "FL",  Industry = "", PhoneNumber = 0, ZipCode = 32206, Latitude = (decimal)30.335868, Longitude = (decimal)-81.653435, Services = GenerateCompanyServices(1, "Joe's Donuts") });
            context.Companies.Add(new Company() { Id = 2, Name = "Mike's Cleaners", StreetNumber = 900, StreetName = "Acorn St", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32209, Latitude = (decimal)30.337646, Longitude = (decimal)-81.686222, Services = GenerateCompanyServices(2, "Mike's Cleaners") });
            context.Companies.Add(new Company() { Id = 3, Name = "Mobile", StreetNumber = 2302, StreetName = "McCoy Creek Blvd", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32204, Latitude = (decimal)30.327868, Longitude = (decimal)-81.688454, Services = GenerateCompanyServices(3, "Mobile") });
            context.Companies.Add(new Company() { Id = 4, Name = "Speedy Garbage Disposal", StreetNumber = 1705, StreetName = "Jones St", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32206, Latitude = (decimal)30.343869, Longitude = (decimal)-81.633694, Services = GenerateCompanyServices(4, "Speedy Garbage Disposal") });
            context.Companies.Add(new Company() { Id = 5, Name = "Elegant Nails", StreetNumber = 1526, StreetName = "Morgana Rd", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32211, Latitude = (decimal)30.33972, Longitude = (decimal)-81.584427, Services = GenerateCompanyServices(5, "Elegant Nails") });
            context.Companies.Add(new Company() { Id = 6, Name = "Prima Vera", StreetNumber = 603, StreetName = "W 46th St", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32208, Latitude = (decimal)30.37527, Longitude = (decimal)-81.660473, Services = GenerateCompanyServices(6, "Prima Vera") });
            context.Companies.Add(new Company() { Id = 7, Name = "Forge Associates", StreetNumber = 1503, StreetName = "W 29th St", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32209, Latitude = (decimal)30.362552, Longitude = (decimal)-81.680579, Services = GenerateCompanyServices(7, "Forge Associates") });
            context.Companies.Add(new Company() { Id = 8, Name = "Yellow Mutt Brewery", StreetNumber = 3573, StreetName = "Hermitage Rd E", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32277, Latitude = (decimal)30.364033, Longitude = (decimal)-81.582217, Services = GenerateCompanyServices(8, "Yellow Mutt Brewery") });
            context.Companies.Add(new Company() { Id = 9, Name = "Put Put Golf", StreetNumber = 2165, StreetName = "W 33rd St", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32209, Latitude = (decimal)30.365218, Longitude = (decimal)-81.696372, Services = GenerateCompanyServices(9, "Put Put Golf") });
            context.Companies.Add(new Company() { Id = 10, Name = "Lucky Cleaners", StreetNumber = 5385, StreetName = "Timber Line Dr", City = "Jacksonville", State = "FL", Industry = "", PhoneNumber = 0, ZipCode = 32277, Latitude = (decimal)30.383878, Longitude = (decimal)-81.611743, Services = GenerateCompanyServices(10, "Lucky Cleaners") });
        }

        private List<CompanyService> GenerateCompanyServices(int companyId, string companyName)
        {
            int servicesToCreate = 3;
            List<CompanyService> list = new List<CompanyService>();
            for (int j = 0; j < servicesToCreate; j++)
            {
                list.Add(new CompanyService() { Id = companyId, ServiceDescription = $"{companyName} service Description {j}", ServiceName = $"{companyName} service name {j}" });
            }
            return list;
        }
    }
}
