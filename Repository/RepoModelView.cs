using System;
using System.Collections.Generic;
using System.Linq;
using logTrip.Interfaces;
using logTrip.Models;

namespace logTrip.Repository
{
    
    public class TripRepository : ITrips
    {
       
        private TripContext Context ;

      
        public TripRepository(TripContext ct){
            Context = ct;
        }

        public List<Trip> GetTrips()=>Context.Trips.ToList();

        public void AddTrip(Trip trip)
        {
            Context.Trips.Add(trip);
            Context.SaveChanges();
        }
    }
}