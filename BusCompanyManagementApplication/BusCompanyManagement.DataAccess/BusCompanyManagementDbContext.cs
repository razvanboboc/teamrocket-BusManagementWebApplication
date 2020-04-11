using BusCompanyManagement.ApplicationLogic.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class BusCompanyManagementDbContext : DbContext
    {
        public BusCompanyManagementDbContext(DbContextOptions<BusCompanyManagementDbContext> options)
                : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many User-PersonalTrip
            modelBuilder.Entity<User>()
                .HasMany(c => c.PersonalTrip)
                .WithOne(e => e.User);
            //many-to-many Trip-Stop
            modelBuilder.Entity<StoppingPoint>()
                .HasKey(bc => new { bc.TripId, bc.StopId });
            modelBuilder.Entity<StoppingPoint>()
                .HasOne(bc => bc.Trip)
                .WithMany(b => b.StoppingPoints)
                .HasForeignKey(bc => bc.TripId);
            modelBuilder.Entity<StoppingPoint>()
                .HasOne(bc => bc.Stop)
                .WithMany(c => c.StoppingPoints)
                .HasForeignKey(bc => bc.StopId);
            //one-to-one PersonalTrip-Trip
            modelBuilder.Entity<PersonalTrip>()
                .HasOne(a => a.Trip)
                .WithOne(b => b.PersonalTrip)
                .HasForeignKey<PersonalTrip>(b => b.PersonalTripId);
            //one-to-many Trip-Bus
            modelBuilder.Entity<Bus>()
                .HasMany(c => c.Trips)
                .WithOne(e => e.Bus);
            //one-to-many Bus-AvailableSeat
            modelBuilder.Entity<Bus>()
                .HasMany(c => c.AvailableSeats)
                .WithOne(e => e.Bus);
            //one-to-one Bus-BusFacility
            modelBuilder.Entity<BusFacility>()
                .HasOne(a => a.Bus)
                .WithOne(b => b.BusFacility)
                .HasForeignKey<BusFacility>(b => b.BusId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalTrip> PersonalTrips { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<AvailableSeat> AvailableSeats { get; set; }
        public DbSet<BusFacility> BusFacilities { get; set; }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
