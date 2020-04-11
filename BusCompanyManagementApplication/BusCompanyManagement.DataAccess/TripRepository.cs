using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    class TripRepository : BaseRepository<Trip>, ITripRepository
    {
        public TripRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }


        public Trip GetTrip(Guid tripId)
        {
            var trip = dbContext.Trips.Where(t => t.TripId == tripId).SingleOrDefault();
            return trip;
        }
    }
}
