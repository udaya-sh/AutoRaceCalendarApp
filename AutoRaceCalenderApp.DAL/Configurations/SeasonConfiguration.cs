using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder
            .HasKey(season => season.SeasonId);

            builder
                .Property(season => season.SeasonId)
                .UseIdentityColumn();

            builder
                .Property(season => season.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(season => season.EndDate)
                .IsRequired()
                .HasMaxLength(15); 

            builder
                 .Property(season => season.StartDate)
                 .IsRequired()
                 .HasMaxLength(15);


            builder
                .HasOne(season => season.Serie)
                .WithMany(serie => serie.Seasons)
                .HasForeignKey(season => season.SerieId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .ToTable("Season");
        }
    }
}
