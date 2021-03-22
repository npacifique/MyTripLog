using System.Collections.Generic;
using logTrip.Models;

namespace logTrip.Interfaces
{
    public interface ITrips
    {
        List<Trip> GetTrips();
        void AddTrip(Trip trip);
    }
}