using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.DataAccess
{
    public class lovelyjubblyMVC6WebApiContext : DbContext
    {
        protected override void OnConfiguring(EntityOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:lovelyjubblymvc6db.database.windows.net,1433;Database=lovelyjubblymvc6db;User ID=lovelyjubblymvc6db@lovelyjubblymvc6db;Password=DarthVader72;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<QBRating> QBRatings { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Standing> Standings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Team
            var entityTeam = modelBuilder.Entity<Team>();
            entityTeam.Table("Teams");
            entityTeam.Property(t => t.TeamId).ForSqlServer().UseIdentity();
            entityTeam.Property(p => p.TeamName).Required().MaxLength(75); //translates to non-nullable
            
            //Division
            var entityDivision = modelBuilder.Entity<Division>();
            entityDivision.Table("Divisions");
            entityDivision.Property(d => d.DivisionId).ForSqlServer().UseIdentity();
            entityDivision.Property(p => p.DivisionName).Required().MaxLength(15); //translates to non-nullable

            //Coach
            var entityCoach = modelBuilder.Entity<Coach>();
            entityCoach.Table("Coaches");
            entityCoach.Property(c => c.CoachId).ForSqlServer().UseIdentity();
            entityCoach.Property(p => p.CoachName).Required().MaxLength(50); //translates to non-nullable

            //QBRating
            var entityQBRating = modelBuilder.Entity<QBRating>();
            entityQBRating.Table("QBRatings");
            entityQBRating.Property(q => q.QBRatingId).ForSqlServer().UseIdentity();
            entityQBRating.Property(p => p.Season).Required().MaxLength(4); 
            entityQBRating.Property(p => p.TeamId).Required();
            entityQBRating.Property(p => p.Completion).Required();
            entityQBRating.Property(p => p.Gain).Required();
            entityQBRating.Property(p => p.Touchdown).Required();
            entityQBRating.Property(p => p.Interception).Required();

            //Fixture
            var entityFixture = modelBuilder.Entity<Fixture>();
            entityFixture.Table("Fixtures");
            entityFixture.Property(q => q.FixtureId).ForSqlServer().UseIdentity();
            entityFixture.Property(p => p.Season).Required().MaxLength(4);
            entityFixture.Property(p => p.Week).Required();
            entityFixture.Property(p => p.AwayTeamId).Required();
            entityFixture.Property(p => p.HomeTeamId).Required();
            entityFixture.Property(p => p.AwayTeamScore);
            entityFixture.Property(p => p.HomeTeamScore);

            //Standing
            var entityStanding = modelBuilder.Entity<Standing>();
            entityStanding.Table("Standings");
            entityStanding.Property(q => q.StandingId).ForSqlServer().UseIdentity();
            entityStanding.Property(p => p.Season).Required().MaxLength(4);
            entityStanding.Property(p => p.DivisionId).Required();
            entityStanding.Property(p => p.TeamId).Required();
            entityStanding.Property(p => p.CoachId).Required();
            entityStanding.Property(p => p.Won).Required();
            entityStanding.Property(p => p.Lost).Required();
            entityStanding.Property(p => p.Tied).Required();
            entityStanding.Property(p => p.PointsFor).Required();
            entityStanding.Property(p => p.PointsAgainst).Required();
        }
    }
}