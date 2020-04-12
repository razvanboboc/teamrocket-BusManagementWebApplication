using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    class HistoryTripRepository : BaseRepository<PersonalTrip>, IHistoryTripRepository
    {
        public HistoryTripRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }

        public PersonalTrip GetHistoryTripByUserId(Guid userId)
        {
            var history = dbContext.PersonalTrips.Where(h => h.User.UserId == userId).SingleOrDefault();
            return history;
        }
    }
}
