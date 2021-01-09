using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SoccerManageApp.Models.Entities
{
    public class Team
    {
        public Team()
        {
            Players=new HashSet<Player>();
            HomeMatches=new HashSet<Match>();
             AwayMatches=new HashSet<Match>();
             Scores=new HashSet<Score>();
             TeamResults=new HashSet<TeamResult>();
             
        }
        public string TeamName { get; set; }
        public string TeamImage{get;set;}
        public int StadiumID { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Match> HomeMatches{get;set;}
        public virtual ICollection<Match> AwayMatches{get;set;}
        public virtual ICollection<Score> Scores{get;set;}
        public virtual ICollection<TeamResult> TeamResults{get;set;}

    }
}