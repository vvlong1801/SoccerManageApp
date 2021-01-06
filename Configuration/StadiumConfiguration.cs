using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.ToTable("stadium");
            builder.Property(p=>p.StadiumName).HasMaxLength(30).IsRequired(true);
            builder.Property(p=>p.City).IsRequired(true);
            builder.HasOne(t=>t.Team).WithOne(s=>s.Stadium).HasForeignKey<Team>(t=>t.StadiumID);

        }
    }
}