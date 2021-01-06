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
            builder.HasOne(m=>m.Match).WithMany(sc=>sc.Scores);
            builder.HasOne(p=>p.Player).WithMany(sc=>sc.Scores);
            builder.HasOne(t=>t.Team).WithMany(sc=>sc.Scores);


        }
    }
}