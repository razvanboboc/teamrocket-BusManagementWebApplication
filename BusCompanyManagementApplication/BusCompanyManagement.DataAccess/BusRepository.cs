using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }
        
        public Bus GetBusByTripId(Guid tripId)
        {
            var bus = dbContext.Buses.Where(b => b.Trips.Any(trip => trip.TripId == tripId)).SingleOrDefault();
            return bus;
        }
        
    }

}
