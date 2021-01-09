using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("player");
            builder.Property(p=>p.PlayerID).HasColumnName("player_id");

            builder.Property(p=>p.FirstName).HasColumnName("first_name").HasMaxLength(30).IsRequired(true);
            builder.Property(p=>p.LastName).HasColumnName("last_name").HasMaxLength(30).IsRequired(true);
            builder.Property(p=>p.Kit).HasColumnName("kit");
            builder.Property(p=>p.Position).HasColumnName("position").HasMaxLength(30);
            builder.Property(p=>p.Country).HasColumnName("country").HasMaxLength(30);
            builder.Property(p=>p.CountryImage).HasColumnName("country_image").HasMaxLength(30);
            builder.Property(p=>p.TeamName).HasColumnName("team_name");
            builder.HasOne(t=>t.Team).WithMany(p=>p.Players);
        }
    }
}