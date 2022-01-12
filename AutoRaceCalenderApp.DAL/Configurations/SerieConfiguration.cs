using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder
            .HasKey(serie => serie.SerieId);

            builder
                .Property(serie => serie.SerieId)
                .UseIdentityColumn();

            builder
                .Property(serie => serie.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
            .Property(serie => serie.SortOrder)
            .IsRequired(false);

            builder
             .Property(serie => serie.StartDate)
             .IsRequired()
             .HasMaxLength(50);

            builder
            .Property(serie => serie.EndDate)
            .IsRequired(false)
            .HasMaxLength(50);


            builder
                .ToTable("Serie");
        }
    }
}
