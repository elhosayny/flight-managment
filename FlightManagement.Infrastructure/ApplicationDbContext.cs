using FlightManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // I need to call this to seed data as the InMemory database don't have migrations
            this.Database.EnsureCreated();
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(
                new Airport() { Id = 1, Name = "Aéroport de Béni Mellal",Latitude = 32.3967064,Longitude = -6.3277034 },
                new Airport() { Id = 2, Name = "Aéroport de Casablanca Mohammed V", Latitude= 32.8383341,Longitude= 32.8383341 }
            );
            modelBuilder.Entity<Airplane>().HasData(
                new Airplane() { Id = 1, Name = "Boeing 787",KeroseneConsumption=30,Speed=800 },
                new Airplane() { Id = 2, Name = "Lockheed SR-71 Blackbird",KeroseneConsumption=40,Speed=900 },
                new Airplane() { Id = 3, Name = "Cirrus SR22",KeroseneConsumption=100,Speed=1300 }
                );
        }
    }
}
