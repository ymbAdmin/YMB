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
        public IEnumerable<FootballPoolUserPicks> userPicks { get; set; }
        public IEnumerable<FootballAlerts> alerts { get; set; }
        public IEnumerable<CheckUserPicks> userPicksCheck { get; set; }
    }
    public class FootballTeam
    {
        [Key]
        public int id { get; set; }
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
        public string imageURL { get; set; }
    }

    public class FootballGame
    {
        [Key]
        public int id { get; set; }
        public int gameId { get; set; }
        public int winningTeamId { get; set; }
        public int lossingTeamId { get; set; }
        virtual public FootballTeam homeTeam { get; set; }
        virtual public FootballTeam awayTeam { get; set; }
        public int? homeTeamScore { get; set; }
        public int? awayTeamScore { get; set; }
        public int weekId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd}")]
        public DateTime gameDate { get; set; }
    }

    public class FootballPoolUsers
    {
        [Key]
        public int id { get; set; }
        [Index(IsUnique = true)]
        public int simpleUserId { get; set; }
        public string userName { get; set; }
        public decimal userScore { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
        public DateTime signedUpDate { get; set; }
        public Boolean hasPaid { get; set; }
    }

    public class FootballPoolUserPicks
    {
        [Key]
        public int id { get; set; }
        public int simpleUserId { get; set; }
        public int weekId { get; set; }
        public int gameId { get; set; }
        public int pick { get; set; }
    }

    public class FootballPoolUserWeeklyScores
    {
        [Key]
        public int id {get; set;}
        public int simpleUserId { get; set; }
        public int weekId {get; set;}
        public decimal score {get; set;}
        public int wins { get; set; }
        public int losses { get; set; }
    }

    public class FootballAlerts
    {

    }

    public class CheckUserPicks
    {
        public int simpleUserId { get; set; }
        public Boolean hasMadePicks { get; set; }
        public int weekId { get; set; }
        public string userName { get; set; }
        public int numberOfPicksMade { get; set; }
    }
}