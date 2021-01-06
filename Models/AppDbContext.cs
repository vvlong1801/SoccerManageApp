using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoccerManageApp.Configuration;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new StadiumConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamResultConfiguration());
        }
        public DbSet<Match> Matches { get;set; }
        public DbSet<Team> Teams{get;set;}
        public DbSet<Player> Players{get;set;}
        public DbSet<Result> Results{get;set;}
        public DbSet<Score> Scores{get;set;}
        public DbSet<Stadium> Stadiums{get;set;}
    }
}