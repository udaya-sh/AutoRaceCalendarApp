using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder
            .HasKey(pilot => pilot.PilootId);

            builder
                .Property(pilot => pilot.PilootId)
                .UseIdentityColumn();

            builder
                .Property(pilot => pilot.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(pilot => pilot.LastName)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(pilot => pilot.DateOfBirth)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(pilot => pilot.Gender)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(pilot => pilot.LicenceNr)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(pilot => pilot.NickName)
               .HasMaxLength(10);

            builder
               .Property(pilot => pilot.PhotoPath)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(pilot => pilot.Length)
               .HasMaxLength(10);

            builder
               .Property(pilot => pilot.Weight)
               .HasMaxLength(10);

            builder
                .ToTable("Pilot");
        }
    }
}
