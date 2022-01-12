using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class CircuitConfiguration : IEntityTypeConfiguration<Circuit>
    {
        public void Configure(EntityTypeBuilder<Circuit> builder)
        {
            builder
            .HasKey(circuit => circuit.CircuitId);

            builder
                .Property(circuit => circuit.CircuitId)
                .UseIdentityColumn();

            builder
                .Property(circuit => circuit.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Circuit");
        }
    }
}
