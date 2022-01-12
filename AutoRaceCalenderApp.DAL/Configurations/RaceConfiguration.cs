using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder
            .HasKey(race => race.RaceId);

            builder
                .Property(race => race.RaceId)
                .UseIdentityColumn();

            builder
                .Property(race => race.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(race => race.EndDate)
                .IsRequired()
                .HasMaxLength(15); 

            builder
                 .Property(race => race.StartDate)
                 .IsRequired()
                 .HasMaxLength(15);

            builder
                .HasOne(race => race.Circuit)
                .WithMany(circuits => circuits.Races)
                .HasForeignKey(race => race.CircuitId);

            builder
                .HasOne(race => race.Season)
               .WithMany(season => season.Races)
               .HasForeignKey(race => race.SeasonId);

            builder
                .ToTable("Race");
        }
    }
}
