using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
   public class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        public TripRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }


        public Trip GetTripBy(Guid tripId)
        {
            var trip = dbContext.Trips.Where(t => t.TripId == tripId).SingleOrDefault();
            return trip;
        }

        public IEnumerable<Trip> GetTripsByArrival(string arrival)
        {
            var trips = dbContext.Trips.Where(t => t.Arrival == arrival).AsEnumerable();
            return trips;
        }

        public IEnumerable<Trip> GetTripsByDestination(string destination)
        {
            var trips = dbContext.Trips.Where(t => t.Destination == destination).AsEnumerable();
            return trips;
        }


        public IEnumerable<Trip> GetTrips()
        {
            var trips = dbContext.Trips.AsEnumerable();
            return trips;
        }

        public IEnumerable<Trip> GetTripsByBusId(Guid busId)
        {
            return dbContext.Trips.Where(t => t.Bus.BusId == busId).AsEnumerable();
            
        }
        public IEnumerable<Trip> GetTripsAccordingToFilters(string arrival, string destination, DateTime arrivalTime)
        {
            var trips = dbContext.Trips.Where(t => t.Arrival == arrival && t.Destination == destination
                                                                        && t.ArrivalTime.Date == arrivalTime.Date).AsEnumerable();
            return trips;
        }
    }
}
