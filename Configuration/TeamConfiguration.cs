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
           builder.HasKey(k=>k.TeamName);
           builder.Property(p=>p.TeamName).HasColumnName("team_name").HasMaxLength(30).IsRequired(true);
           builder.Property(p=>p.TeamImage).HasColumnName("team_image").HasMaxLength(30).IsRequired(true);
           builder.Property(p=>p.StadiumID).HasColumnName("stadium_id");
           builder.HasMany(p=>p.Players).WithOne(t=>t.Team).HasForeignKey(fk=>fk.TeamName);
           builder.HasMany(hm=>hm.HomeMatches).WithOne(ht=>ht.HomeTeam).HasForeignKey(k=>k.HomeTeamName);
           builder.HasMany(hm=>hm.AwayMatches).WithOne(ht=>ht.AwayTeam).HasForeignKey(k=>k.AwayTeamName);

           
        }
    }
}