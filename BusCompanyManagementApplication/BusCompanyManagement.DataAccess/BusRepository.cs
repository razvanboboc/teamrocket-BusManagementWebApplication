using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    /*public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }
        
        public Bus GetBusByTripId(Guid tripId)
        {
            
            return dbContext.Buses
                            .Where(bus => bus.Trips
                                              .Where(trip => trip.TripId == tripId).SingleOrDefault() == tripId) 
                            .SingleOrDefault();

            Bus bus = null;

            var selectedTrip = dbContext.Trips
                                         .Where(trip => trip.TripId == tripId)
                                         .SingleOrDefault();

            return Bus.selectedTrip
                            .Where(bus => selectedTrip.TripId == tripId)
                            .SingleOrDefault();
                            
        }
        
    }
*/
}
