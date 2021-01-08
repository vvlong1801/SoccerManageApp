namespace SoccerManageApp.Models.Entities
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int MatchID { get; set; }
        public virtual Match Match { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public string TeamName { get; set; }
        public virtual Team Team { get; set; }
    }
}