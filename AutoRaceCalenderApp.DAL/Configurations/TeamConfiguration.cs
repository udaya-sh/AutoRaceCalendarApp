using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
            .HasKey(team => team.TeamNr);

            builder
                .Property(team => team.TeamNr)
                .UseIdentityColumn();

            builder
                .Property(team => team.Name)
                .IsRequired()
                .HasMaxLength(50);


            builder
                .ToTable("Team");
        }
    }
}
