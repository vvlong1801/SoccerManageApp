using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class TeamResultConfiguration : IEntityTypeConfiguration<TeamResult>
    {

        public void Configure(EntityTypeBuilder<TeamResult> builder)
        {
           builder.ToTable("team_result");
           builder.HasKey(k=>k.TeamID);
           builder.Property(p=>p.TeamID).HasColumnName("team_id");
           builder.Property(p=>p.WinMatch).HasColumnName("win_match");
           builder.Property(p=>p.LoseMatch).HasColumnName("lose_match");
           builder.Property(p=>p.DrawMatch).HasColumnName("draw_match");
           builder.Property(p=>p.Point).HasColumnName("point");
           builder.HasOne(t=>t.Team).WithMany(tr=>tr.TeamResults).HasForeignKey(t=>t.TeamID);
          
          
        }
    }
}