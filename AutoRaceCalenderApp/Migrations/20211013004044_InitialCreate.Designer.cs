﻿// <auto-generated />
using System;
using AutoRaceCalenderApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoRaceCalenderApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211013004044_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Circuit", b =>
                {
                    b.Property<long>("CircuitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("StraatNr")
                        .HasColumnType("int");

                    b.HasKey("CircuitID");

                    b.ToTable("Circuit");
                });

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Pilot", b =>
                {
                    b.Property<long>("PilootId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<long>("LicenceNr")
                        .HasColumnType("bigint");

                    b.Property<string>("NickName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("varchar(50)");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("PilootId");

                    b.ToTable("Pilot");
                });

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Race", b =>
                {
                    b.Property<long>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("RaceId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Season", b =>
                {
                    b.Property<long>("SeizoenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("SeizoenId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Serie", b =>
                {
                    b.Property<long>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("SerieId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("AutoRaceCalenderApp.Model.Team", b =>
                {
                    b.Property<long>("TeamNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("TeamNr");

                    b.ToTable("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
