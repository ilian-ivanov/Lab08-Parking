using Lab08_Parking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Lab08_Parking.Data
{
    public class ParkingContext: DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.RegNumber).IsUnique();
            modelBuilder.Entity<Vehicle>().Property(v => v.RegNumber).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Vehicle>().Property(v => v.ParkingId).IsRequired();

            modelBuilder.Entity<Parking>().Property(p => p.Size).IsRequired();
            modelBuilder.Entity<Parking>().Property(p => p.DailyRate).IsRequired().HasPrecision(5,2);
            modelBuilder.Entity<Parking>().Property(p => p.NightlyRate).IsRequired().HasPrecision(5,2);
            modelBuilder.Entity<Parking>().Property(p => p.DailyRateStartHour).IsRequired();
            modelBuilder.Entity<Parking>().Property(p => p.DailyRateStopHour).IsRequired();

            modelBuilder.Entity<DiscountCard>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<DiscountCard>().Property(c => c.ParkingId).IsRequired();

            // Seed initial data
            modelBuilder.Entity<Parking>()
                .HasData(
                    new Parking
                    {
                        Id = 1,
                        Size = 200,
                        DailyRate = 3,
                        NightlyRate = 2,
                        DailyRateStartHour = 8,
                        DailyRateStopHour = 18
                    }
                );

            modelBuilder.Entity<DiscountCard>()
                .HasData(
                    new DiscountCard { Id = 1, Name = "Silver", Discount = 10, ParkingId = 1 },
                    new DiscountCard { Id = 2, Name = "Gold", Discount = 15, ParkingId = 1 },
                    new DiscountCard { Id = 3, Name = "Platinum", Discount = 20, ParkingId = 1 }
                );

            modelBuilder.Entity<Vehicle>()
                .HasData(
                    new Vehicle {  Id = 1, DiscountCardId = 1, ParkingId = 1, RegNumber = "1111", Size = 1, EntryTime = DateTime.Now.AddHours(-1)},
                    new Vehicle {  Id = 2, DiscountCardId = 2, ParkingId = 1, RegNumber = "1112", Size = 2, EntryTime = DateTime.Now.AddHours(-5)},
                    new Vehicle {  Id = 3, DiscountCardId = 3, ParkingId = 1, RegNumber = "1113", Size = 4, EntryTime = DateTime.Now.AddHours(-7)},
                    new Vehicle {  Id = 4, DiscountCardId = 1, ParkingId = 1, RegNumber = "1114", Size = 1, EntryTime = DateTime.Now.AddHours(-11)},
                    new Vehicle {  Id = 5, DiscountCardId = 1, ParkingId = 1, RegNumber = "1115", Size = 2, EntryTime = DateTime.Now.AddHours(-15)},
                    new Vehicle {  Id = 6, DiscountCardId = 3, ParkingId = 1, RegNumber = "1116", Size = 4, EntryTime = DateTime.Now.AddHours(-23)},
                    new Vehicle {  Id = 7, DiscountCardId = null, ParkingId = 1, RegNumber = "1117", Size = 1, EntryTime = DateTime.Now.AddHours(-35)}
                );
        }
    }
}
