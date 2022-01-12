using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Configurations
{
    public class RaceTeamPilotConfiguration : IEntityTypeConfiguration<RaceTeamPilot>
    {
        public void Configure(EntityTypeBuilder<RaceTeamPilot> builder)
        {
            builder
            .HasKey(rtp => new { rtp.PilotId, rtp.RaceId, rtp.TeamNr });

            builder
               .HasOne(rtp => rtp.Team)
               .WithMany(team => team.RaceTeamPilots)
               .HasForeignKey(rtp => rtp.TeamNr);

            builder
                .HasOne(rtp => rtp.Pilot)
                .WithMany(pilot => pilot.RaceTeamPilots)
                .HasForeignKey(rtp => rtp.PilotId);

            builder
                .HasOne(rtp => rtp.Race)
               .WithMany(race => race.RaceTeamPilots)
               .HasForeignKey(rtp => rtp.RaceId);

            builder
                .ToTable("RaceTeamPilot");
        }
    
}
}
