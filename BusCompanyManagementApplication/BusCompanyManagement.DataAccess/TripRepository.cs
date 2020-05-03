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

        public Trip GetTripByArrival(string arrival)
        {
            var trip = dbContext.Trips.Where(t => t.Arrival == arrival).SingleOrDefault();
            return trip;
        }

        public Trip GetTripByDestination(string destination)
        {
            var trip = dbContext.Trips.Where(t => t.Destination == destination).SingleOrDefault();
            return trip;
        }
    }
}
