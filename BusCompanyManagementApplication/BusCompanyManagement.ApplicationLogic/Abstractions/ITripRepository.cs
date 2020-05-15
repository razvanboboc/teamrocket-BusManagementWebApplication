using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Abstractions
{
    public interface ITripRepository : IRepository<Trip>
    {
        Trip GetTripBy(Guid tripId);
        IEnumerable<Trip> GetTripsByDestination(string destination); 
        IEnumerable<Trip> GetTripsByArrival(string arrival);

        IEnumerable<Trip> GetTripsAccordingToFilters(string arrival, string destination, DateTime arrivalTime);
        IEnumerable<Trip> GetTrips();
    }
       
}
