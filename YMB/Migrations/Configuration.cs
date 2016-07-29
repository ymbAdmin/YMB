namespace YMB.Migrations
{
    using System;
    using System.Data.Entity;
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

            Boolean toSeed = false;
            if (toSeed)
            {
                SeedTeamData(context);
                SeedGameData(context);
            }
            
            


        }

        protected void SeedGameData(ApplicationDbContext context)
        {
            //week 1
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 26), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 8, 20, 30, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 19), awayTeam = context.FootballTeam.Single(f => f.teamId == 8), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 9), awayTeam = context.FootballTeam.Single(f => f.teamId == 23), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 24), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 28), awayTeam = context.FootballTeam.Single(f => f.teamId == 16), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 10), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 1), awayTeam = context.FootballTeam.Single(f => f.teamId == 5), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 14), awayTeam = context.FootballTeam.Single(f => f.teamId == 15), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 6), awayTeam = context.FootballTeam.Single(f => f.teamId == 2), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 25), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 31), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 17), awayTeam = context.FootballTeam.Single(f => f.teamId == 20), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 12), awayTeam = context.FootballTeam.Single(f => f.teamId == 22), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 3), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 11, 20, 30, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 7), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 12, 19, 10, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 1, homeTeam = context.FootballTeam.Single(f => f.teamId == 30), awayTeam = context.FootballTeam.Single(f => f.teamId == 32), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 12, 22, 20, 0) });
            //week 2
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 2), awayTeam = context.FootballTeam.Single(f => f.teamId == 1), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 15, 20, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 18), awayTeam = context.FootballTeam.Single(f => f.teamId == 17), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 11), awayTeam = context.FootballTeam.Single(f => f.teamId == 14), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 26), awayTeam = context.FootballTeam.Single(f => f.teamId == 30), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 22), awayTeam = context.FootballTeam.Single(f => f.teamId == 9), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 3), awayTeam = context.FootballTeam.Single(f => f.teamId == 4), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 20), awayTeam = context.FootballTeam.Single(f => f.teamId == 28), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 8), awayTeam = context.FootballTeam.Single(f => f.teamId == 6), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 7), awayTeam = context.FootballTeam.Single(f => f.teamId == 5), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 13, 00, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 29), awayTeam = context.FootballTeam.Single(f => f.teamId == 27), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 32), awayTeam = context.FootballTeam.Single(f => f.teamId == 31), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 05, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 15), awayTeam = context.FootballTeam.Single(f => f.teamId == 10), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 16), awayTeam = context.FootballTeam.Single(f => f.teamId == 25), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 13), awayTeam = context.FootballTeam.Single(f => f.teamId == 12), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 16, 25, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 23), awayTeam = context.FootballTeam.Single(f => f.teamId == 21), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 18, 20, 30, 0) });
            context.FootballGame.Add(new FootballGame() { weekId = 2, homeTeam = context.FootballTeam.Single(f => f.teamId == 24), awayTeam = context.FootballTeam.Single(f => f.teamId == 19), homeTeamScore = 0, awayTeamScore = 0, gameDate = new DateTime(2016, 9, 19, 20, 30, 0) });
        }

        protected void SeedTeamData(ApplicationDbContext context)
        {
            context.FootballTeam.Add(new FootballTeam() { teamName = "New York Jets", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Buffalo Bills", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "New England Patriots", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Miami Dolphins", win = 0, loss = 0, tie = 0, division = "ACE", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Cincinnati Bengals", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Baltimore Ravens", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Pittsburg Steelers", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Cleveland Browns", win = 0, loss = 0, tie = 0, division = "ACN", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Tennessee Titans", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Jacksonville Jaguards", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Houston Texans", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Indianapolis Colts", win = 0, loss = 0, tie = 0, division = "ACS", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Denver Broncos", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Kansas City Chiefs", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "San Diego Chargers", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Oakland Raiders", win = 0, loss = 0, tie = 0, division = "ACW", conference = "AFC", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Dallas Cowboys", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Washington Redskins", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Philadelphia Eagles", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "New York Giants", win = 0, loss = 0, tie = 0, division = "NCE", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Green Bay Packers", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Detroit Lions", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Minnesota Vikings", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Chicago Bears", win = 0, loss = 0, tie = 0, division = "NCN", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Atlanta Falcons", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Carolina Panthers", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Tampa Bay Buccaneers", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "New Orleans Saints", win = 0, loss = 0, tie = 0, division = "NCS", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Arizona Cardinals", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "San Francisco 49ers", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Seattle Seahawks", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
            context.FootballTeam.Add(new FootballTeam() { teamName = "Los Angeles Rams", win = 0, loss = 0, tie = 0, division = "NCW", conference = "NCF", winPercentage = .000m, pointsFor = 0, pointsAgainst = 0 });
        }
    }
}