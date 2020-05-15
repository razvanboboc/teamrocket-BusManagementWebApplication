﻿// <auto-generated />
using System;
using BusCompanyManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusCompanyManagement.DataAccess.Migrations
{
    [DbContext(typeof(BusCompanyManagementDbContext))]
    [Migration("20200413062035_ModifyTrip")]
    partial class ModifyTrip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.Announcement", b =>
                {
                    b.Property<Guid>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnouncementId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.AvailableSeat", b =>
                {
                    b.Property<Guid>("AvailableSeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvailableSeatId");

                    b.HasIndex("BusId");

                    b.ToTable("AvailableSeats");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.Bus", b =>
                {
                    b.Property<Guid>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BusBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.BusFacility", b =>
                {
                    b.Property<Guid>("BusFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HasAirConditioning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HasBabyChair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HasTv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusFacilityId");

                    b.HasIndex("BusId")
                        .IsUnique();

                    b.ToTable("BusFacilities");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.PersonalTrip", b =>
                {
                    b.Property<Guid>("PersonalTripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.Property<Guid?>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonalTripId");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("PersonalTrips");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.Stop", b =>
                {
                    b.Property<Guid>("StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StopDuration")
                        .HasColumnType("datetime2");

                    b.Property<string>("TouristicPoints")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.StoppingPoint", b =>
                {
                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripId", "StopId");

                    b.HasIndex("StopId");

                    b.ToTable("StoppingPoint");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.Trip", b =>
                {
                    b.Property<Guid>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Arrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DestinationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TripId");

                    b.HasIndex("BusId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.AvailableSeat", b =>
                {
                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Bus", "Bus")
                        .WithMany("AvailableSeats")
                        .HasForeignKey("BusId");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.BusFacility", b =>
                {
                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Bus", "Bus")
                        .WithOne("BusFacility")
                        .HasForeignKey("BusCompanyManagement.ApplicationLogic.DataModel.BusFacility", "BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.PersonalTrip", b =>
                {
                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");

                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.User", "User")
                        .WithMany("PersonalTrip")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.StoppingPoint", b =>
                {
                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Stop", "Stop")
                        .WithMany("StoppingPoints")
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Trip", "Trip")
                        .WithMany("StoppingPoints")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusCompanyManagement.ApplicationLogic.DataModel.Trip", b =>
                {
                    b.HasOne("BusCompanyManagement.ApplicationLogic.DataModel.Bus", "Bus")
                        .WithMany("Trips")
                        .HasForeignKey("BusId");
                });
#pragma warning restore 612, 618
        }
    }
}
