using Microsoft.EntityFrameworkCore;
using System;

namespace logTrip.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> option) : base(option) {}

        public DbSet<Trip> Trips {get; set;}

        protected override void OnModelCreating (ModelBuilder modelBuilder){
            DateTime today = DateTime.Now;

            modelBuilder.Entity<Trip>().HasData(
                new Trip {
                    TripId  = 1,
                    Destination = "Paris",
                    StartDate = today,
                    EndDate = today.AddDays(1),
                    Accommodation = "Night starts hotel",
                    AccommodationPhone = "501-388-0001",
                    AccommodationEmail = "stars@booling.com",
                    ThingToDo1 = "Conference",


                },

                new Trip
                {
                    TripId = 2,
                    Destination = "New York",
                    StartDate = today.AddDays(10),
                    EndDate = today.AddDays(16),
                    Accommodation = "Sunset hotel",
                    AccommodationPhone = "801-846-2701",
                    AccommodationEmail = "info@sunset.com",
                    ThingToDo1 = "Go to central park",
                    ThingToDo2 = "Visit the world Trade Center's Liberty Park",
                    ThingToDo3 = "Grand Central Terminal"

                },

                new Trip
                {
                    TripId = 3,
                    Destination = "Boston",
                    StartDate = today.AddDays(20),
                    EndDate = today.AddDays(23),
                    Accommodation = "Holiday-in Hotel",
                    AccommodationPhone = "901-786-4325",
                    AccommodationEmail = "booking@holiday.com",
                    ThingToDo1 = "",
                    ThingToDo2 = "",
                    ThingToDo3 = ""

                }
            );
        }
        
    }
}