using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration {
    public class MatchConfiguration : IEntityTypeConfiguration<Match> {
        public void Configure (EntityTypeBuilder<Match> builder) {
            builder.ToTable ("match");
            builder.Property (p => p.MatchID).HasColumnName ("match_id");
            builder.Property (p => p.Datetime).HasColumnName ("datetime");
            builder.Property (p => p.Attendance).HasColumnName ("attendance");
            builder.Property (p => p.HomeTeamName).HasColumnName ("hometeam_name");
            builder.Property (p => p.AwayTeamName).HasColumnName ("awayteam_name");
            builder.Property (p => p.StadiumID).HasColumnName ("stadium_id");

            builder.HasKey (k => k.MatchID);
            builder.HasOne (h => h.HomeTeam).WithMany (hm => hm.HomeMatches);
            builder.HasOne (h => h.AwayTeam).WithMany (am => am.AwayMatches);
            builder.HasOne (s => s.Stadium).WithMany (m => m.Matches);
            builder.HasOne (r => r.Result).WithOne (m => m.Match).HasForeignKey<Result> (f => f.MatchID);
            

        }
    }
}