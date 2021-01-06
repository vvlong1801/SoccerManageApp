using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManageApp.Models.Entities
{
    public class TeamResult
    {
        public TeamResult()
        {
            WinMatch=0;
            LoseMatch=0;
            Point=0;
        }
        [Key]
        public int TeamID{get;set;}
        public int WinMatch { get; set; }
        public int DrawMatch { get; set; }
         public int LoseMatch { get;set;}
         public int Point{get;set;}
         public virtual Team Team { get;set;}
    }
}