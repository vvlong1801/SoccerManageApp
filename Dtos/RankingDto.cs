namespace SoccerManageApp.Dtos
{
    public class RankingDto
    {
        public string TeamName{get;set;}
        public string TeamImage{get;set;}
        public int WinMatch { get; set; }
        public int DrawMatch { get; set; }
         public int LoseMatch { get;set;}
         public int GoalFor{get;set;}
         public int GoalAgainst{get;set;}
         public int MatchPlayed{get;set;}
         public int Point{get;set;}
 
    }
}