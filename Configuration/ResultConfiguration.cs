using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Configuration
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
           builder.ToTable("result");
           builder.Property(p=>p.MatchID).HasColumnName("match_id");
           builder.Property(p=>p.Homeres).HasColumnName("home_res");
           builder.Property(p=>p.Awayres).HasColumnName("away_res");

           builder.HasKey(k=>k.MatchID);
    }
    }
}