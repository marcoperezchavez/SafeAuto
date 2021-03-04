﻿// <auto-generated />
using System;
using BEApi.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BEApi.Migrations
{
    [DbContext(typeof(SafeAutoDBContext))]
    [Migration("20210303162926_addedDB")]
    partial class addedDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BEApi.Models.InformationSafeAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndTrip")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("Miles")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SafeAutoId")
                        .HasColumnType("int");

                    b.Property<string>("StartTrip")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("SafeAutoId");

                    b.ToTable("InformationSafeAuto");
                });

            modelBuilder.Entity("BEApi.Models.SafeAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("SafeAuto");
                });

            modelBuilder.Entity("BEApi.Models.InformationSafeAuto", b =>
                {
                    b.HasOne("BEApi.Models.SafeAuto", "SafeAuto")
                        .WithMany("informationSafeAutos")
                        .HasForeignKey("SafeAutoId");

                    b.Navigation("SafeAuto");
                });

            modelBuilder.Entity("BEApi.Models.SafeAuto", b =>
                {
                    b.Navigation("informationSafeAutos");
                });
#pragma warning restore 612, 618
        }
    }
}