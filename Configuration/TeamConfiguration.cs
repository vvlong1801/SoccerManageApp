using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
           builder.ToTable("team");
           builder.Property(p=>p.TeamID).HasColumnName("team_id");
           builder.Property(p=>p.TeamName).HasColumnName("team_name").HasMaxLength(30).IsRequired(true);
           builder.Property(p=>p.TeamImage).HasColumnName("team_image").HasMaxLength(30).IsRequired(true);
           builder.Property(p=>p.StadiumID).HasColumnName("stadium_id");

           
        }
    }
}