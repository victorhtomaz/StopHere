﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StopHere.Api.Data;

#nullable disable

namespace StopHere.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250107000548_First_Migration")]
    partial class First_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StopHere.Core.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("StopHere.Core.Entities.EntryExitRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TIME")
                        .HasColumnName("Duration");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("EntryDate");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("ExitDate");

                    b.Property<string>("LicensePlateValue")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("LicensePlateValue");

                    b.Property<Guid>("ParkingSpaceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ParkingSpaceId");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpaceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("EntryExitRecord", (string)null);
                });

            modelBuilder.Entity("StopHere.Core.Entities.ParkingPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("BIT")
                        .HasColumnName("IsOccupied");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("ParkingPlace", (string)null);
                });

            modelBuilder.Entity("StopHere.Core.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Color");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Model");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("StopHere.Core.Entities.Client", b =>
                {
                    b.OwnsOne("StopHere.Core.ValueObjects.ClientService", "Service", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("ExpiryDate")
                                .HasColumnType("DATETIME2")
                                .HasColumnName("Service_ExpiryDate");

                            b1.Property<short>("Type")
                                .HasColumnType("SMALLINT")
                                .HasColumnName("Service_Type");

                            b1.HasKey("ClientId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("StopHere.Core.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Phone_Number");

                            b1.HasKey("ClientId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Phone")
                        .IsRequired();

                    b.Navigation("Service")
                        .IsRequired();
                });

            modelBuilder.Entity("StopHere.Core.Entities.EntryExitRecord", b =>
                {
                    b.HasOne("StopHere.Core.Entities.ParkingPlace", "ParkingPlace")
                        .WithMany()
                        .HasForeignKey("ParkingSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StopHere.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("EntryExitRecords")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingPlace");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("StopHere.Core.Entities.ParkingPlace", b =>
                {
                    b.HasOne("StopHere.Core.Entities.Client", "Client")
                        .WithOne("ParkingPlace")
                        .HasForeignKey("StopHere.Core.Entities.ParkingPlace", "ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("StopHere.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("StopHere.Core.Entities.Client", "Client")
                        .WithOne("Vehicle")
                        .HasForeignKey("StopHere.Core.Entities.Vehicle", "ClientId");

                    b.OwnsOne("StopHere.Core.ValueObjects.LicensePlate", "LicensePlate", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("LicensePlate_Value");

                            b1.HasKey("VehicleId");

                            b1.ToTable("Vehicle");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Client");

                    b.Navigation("LicensePlate")
                        .IsRequired();
                });

            modelBuilder.Entity("StopHere.Core.Entities.Client", b =>
                {
                    b.Navigation("ParkingPlace")
                        .IsRequired();

                    b.Navigation("Vehicle")
                        .IsRequired();
                });

            modelBuilder.Entity("StopHere.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("EntryExitRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
