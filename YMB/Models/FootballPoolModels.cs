using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Models
{
    public class FootballPoolViewModel
    {
        public FootballTeam footballTeam { get; set; }
        public FootballSchedule footballSchedule { get; set; }
        public FootballGame footballGame { get; set; }
        public FootballPoolUsers user { get; set; }

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

    public class FootballSchedule
    {
        [Key]
        public int id { get; set; }
        public FootballGame game { get; set; }
    }

    public class FootballGame
    {
        public int id { get; set; }
        public FootballTeam homeTeam { get; set; }
        public FootballTeam awayTeam { get; set; }
        public int homeTeamScore { get; set; }
        public int awayTeamScore { get; set; }
        public int weekId { get; set; }
        public DateTime gameDate { get; set; }
    }

    public class FootballPoolUsers
    {
        [Key]
        public int simpleUserId { get; set; }
        public string userName { get; set; }
        public ApplicationUser userId { get; set; }
        public decimal userScore { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
    }
}