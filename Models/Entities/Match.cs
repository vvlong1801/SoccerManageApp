using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerManageApp.Models.Entities
 {
    public class Match {
        public Match () {
            Scores = new HashSet<Score> ();
        }
        public int MatchID { get; set; }

        [DataType (DataType.Date)]
        public DateTime Datetime { get; set; }
        public int Attendance { get; set; }
        public string HomeTeamName { get; set; }
        public virtual Team HomeTeam { get; set; }
        public string AwayTeamName { get; set; }

        public virtual Team AwayTeam { get; set; }
        public int StadiumID { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Result Result { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}