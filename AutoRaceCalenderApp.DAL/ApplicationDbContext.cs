using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;
using DAL.Configurations;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceTeamPilot> RaceTeamPilots { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CircuitConfiguration());

            builder
             .ApplyConfiguration(new PilotConfiguration());

            builder
            .ApplyConfiguration(new RaceConfiguration() );

            builder
             .ApplyConfiguration(new RaceTeamPilotConfiguration() );

            builder
             .ApplyConfiguration(new SeasonConfiguration());

            builder
             .ApplyConfiguration(new SerieConfiguration() );

            builder
            .ApplyConfiguration(new TeamConfiguration());

            
        }
    }
}
