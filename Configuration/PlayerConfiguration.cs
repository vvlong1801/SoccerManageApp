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
            builder.Property(p=>p.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(p=>p.LastName).HasMaxLength(30).IsRequired(true);
            builder.HasOne(t=>t.Team).WithMany(p=>p.Players);
        }
    }
}