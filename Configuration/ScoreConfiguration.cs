using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("score");
            builder.Property(p=>p.ScoreID).HasColumnName("score_id");
            builder.Property(p=>p.MatchID).HasColumnName("match_id");
            builder.Property(p=>p.PlayerID).HasColumnName("player_id");
            builder.Property(p=>p.TeamID).HasColumnName("team_id");
            builder.HasOne(m=>m.Match).WithMany(sc=>sc.Scores);
            builder.HasOne(p=>p.Player).WithMany(sc=>sc.Scores);
            builder.HasOne(t=>t.Team).WithMany(sc=>sc.Scores);


        }
    }
}