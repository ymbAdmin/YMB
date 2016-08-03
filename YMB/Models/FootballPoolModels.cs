using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class FootballPoolViewModel
    {
        public IEnumerable<FootballTeam> footballTeams { get; set; }
        public IEnumerable<FootballGame> footballGames { get; set; }
        public IEnumerable<FootballPoolUsers> users { get; set; }
        public IEnumerable<FootballGameResults> gameResults { get; set; }
        public IEnumerable<FootballPoolUserPicks> userPicks { get; set; }

    }
    public class FootballTeam
    {
        [Key]
        public int teamId { get; set; }
        public string teamName { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
        public int tie { get; set; }
        public string division { get; set; } //ACN, ACE, ACS, ASW, NCN, NCE, NCS, NCW
        public string conference { get; set; } //AFC or NFC
        public decimal winPercentage { get; set; }
        public int pointsFor { get; set; }
        public int pointsAgainst { get; set; }
    }

    public class FootballGame
    {
        [Key]
        public int gameId { get; set; }
        virtual public FootballTeam homeTeam { get; set; }
        virtual public FootballTeam awayTeam { get; set; }
        public int homeTeamScore { get; set; }
        public int awayTeamScore { get; set; }
        public int weekId { get; set; }
        public DateTime gameDate { get; set; }
    }

    public class FootballPoolUsers
    {
        [Key]
        public int id { get; set; }
        [Index(IsUnique = true)]
        public int simpleUserId { get; set; }
        public string userName { get; set; }
        virtual public ApplicationUser userId { get; set; }
        public decimal userScore { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
    }

    public class FootballPoolUserPicks
    {
        [Key]
        public int id { get; set; }
        public int simpleUserId { get; set; }
        public int weekId { get; set; }
        virtual public FootballGame gameId { get; set; }
        public int pick { get; set; }
    }

    public class FootballGameResults
    {
        [Key]
        public int id { get; set; }
        virtual public FootballGame gameId { get; set; }
        public int winningTeamId { get; set; }
    }

}