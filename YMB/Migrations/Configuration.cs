namespace YMB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YMB.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (true)
            {
                //SeedTeamData(context);
                SeedGameData(context);
                //SeedUserPickData(context, 3);
                //ResetFootballTables(context);
            }
        }

        private void ResetFootballTables(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE FootballPoolUserPicks");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE FootballPoolUserWeeklyScores");
            context.Database.ExecuteSqlCommand("UPDATE FootballGames set homeTeamScore = NULL, awayTeamScore = NULL, winningTeamId = 0, lossingTeamId = 0");
            context.Database.ExecuteSqlCommand("UPDATE FootballPoolUsers set userScore = 0.00, win = 0, loss = 0");
        }
        private void SeedUserPickData(ApplicationDbContext context, int simpleUserId)
        {
            context.Database.ExecuteSqlCommand("truncate table dbo.FootballPoolUserPicks;");
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() {gameId = 1, pick = 13, simpleUserId = simpleUserId, weekId = 1});
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 2, pick = 19, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 3, pick = 9, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 4, pick = 11, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 5, pick = 28, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 6, pick = 10, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 7, pick = 1, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId = 8, pick = 14, simpleUserId = simpleUserId, weekId = 1 });
            context.FootballPoolUserPicks.Add(new FootballPoolUserPicks() { gameId =  9, pick = 6, simpleUserId = simpleUserId, weekId = 1 });
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
            //week 1
            //context.FootballGame.Add(new FootballGame() { gameId = 1, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 26), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 8, 20, 30, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 2, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 19), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 3, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 9), awayTeam = context.FootballTeam.Single(f => f.teamId == 23), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 4, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 24), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 5, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 28), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 6, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 10), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 7, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 1), awayTeam = context.FootballTeam.Single(f => f.teamId == 5), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 8, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 14), awayTeam = context.FootballTeam.Single(f => f.teamId == 15), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 9, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 6), awayTeam = context.FootballTeam.Single(f => f.teamId == 2), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 10, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 25), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 11, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 31), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 05, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 12, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 17), awayTeam = context.FootballTeam.Single(f => f.teamId == 20), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 13, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 12), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 14, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 3), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 20, 30, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 15, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 7), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 12, 19, 10, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 16, weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 30), awayTeam = context.FootballTeam.Single(f => f.teamId == 32), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 12, 22, 20, 0) });
            //week 2
            //context.FootballGame.Add(new FootballGame() { gameId = 17, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 2), awayTeam = context.FootballTeam.Single(f => f.teamId == 1), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 15, 20, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 18, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 17), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 19, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 14), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 20, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 26), awayTeam = context.FootballTeam.Single(f => f.teamId == 30), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 21, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 22), awayTeam = context.FootballTeam.Single(f => f.teamId == 9), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 22, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 3), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 23, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 20), awayTeam = context.FootballTeam.Single(f => f.teamId == 28), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 24, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 8), awayTeam = context.FootballTeam.Single(f => f.teamId == 6), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 25, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 7), awayTeam = context.FootballTeam.Single(f => f.teamId == 5), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 26, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 05, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 27, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 32), awayTeam = context.FootballTeam.Single(f => f.teamId == 31), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 05, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 28, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 15), awayTeam = context.FootballTeam.Single(f => f.teamId == 10), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 29, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 16), awayTeam = context.FootballTeam.Single(f => f.teamId == 25), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 30, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 12), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 31, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 23), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 20, 30, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 32, weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 24), awayTeam = context.FootballTeam.Single(f => f.teamId == 19), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 19, 20, 30, 0) });
            //week 3
            //context.FootballGame.Add(new FootballGame() { gameId = 33, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 3), awayTeam = context.FootballTeam.Single(f => f.teamId == 11), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 22, 20, 30, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 34, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 10), awayTeam = context.FootballTeam.Single(f => f.teamId == 6), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 35, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 20), awayTeam = context.FootballTeam.Single(f => f.teamId == 18), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 36, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 21), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 37, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 4), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 38, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 26), awayTeam = context.FootballTeam.Single(f => f.teamId == 23), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 39, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 5), awayTeam = context.FootballTeam.Single(f => f.teamId == 13), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 40, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 2), awayTeam = context.FootballTeam.Single(f => f.teamId == 29), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 41, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 9), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 13, 00, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 42, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 27), awayTeam = context.FootballTeam.Single(f => f.teamId == 32), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 16, 05, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 43, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 31), awayTeam = context.FootballTeam.Single(f => f.teamId == 30), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 16, 05, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 44, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 19), awayTeam = context.FootballTeam.Single(f => f.teamId == 7), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 45, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 14), awayTeam = context.FootballTeam.Single(f => f.teamId == 1), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 46, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 12), awayTeam = context.FootballTeam.Single(f => f.teamId == 15), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 16, 25, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 47, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 17), awayTeam = context.FootballTeam.Single(f => f.teamId == 24), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 25, 10, 30, 0) });
            //context.FootballGame.Add(new FootballGame() { gameId = 48, weekId = 3, homeTeam = context.FootballTeam.Single(f => f.teamId == 28), awayTeam = context.FootballTeam.Single(f => f.teamId == 25), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 26, 22, 30, 0) });
            //week 4
            context.FootballGame.Add(new FootballGame() { gameId = 49, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 5), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 29, 20, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 50, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 10), awayTeam = context.FootballTeam.Single(f => f.teamId == 12), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 9, 30, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 51, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 3), awayTeam = context.FootballTeam.Single(f => f.teamId == 2), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 52, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 9), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 53, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 24), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 54, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 25), awayTeam = context.FootballTeam.Single(f => f.teamId == 26), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 55, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 1), awayTeam = context.FootballTeam.Single(f => f.teamId == 31), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 56, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 6), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 57, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 58, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 27), awayTeam = context.FootballTeam.Single(f => f.teamId == 13), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 59, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 32), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 60, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 30), awayTeam = context.FootballTeam.Single(f => f.teamId == 17), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 61, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 15), awayTeam = context.FootballTeam.Single(f => f.teamId == 28), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 62, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 7), awayTeam = context.FootballTeam.Single(f => f.teamId == 14), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 2, 10, 30, 0) });
            context.FootballGame.Add(new FootballGame() { gameId = 63, weekId = 4, homeTeam = context.FootballTeam.Single(f => f.teamId == 23), awayTeam = context.FootballTeam.Single(f => f.teamId == 20), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 10, 3, 20, 30, 0) });
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
    }
}