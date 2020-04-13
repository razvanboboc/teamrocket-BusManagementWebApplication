using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class HistoryTripRepository : BaseRepository<PersonalTrip>, IHistoryTripRepository
    {
        public HistoryTripRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }

        public PersonalTrip GetHistoryTripByUserId(Guid userId)
        {
            var history = dbContext.PersonalTrips.Where(h => h.User.UserId == userId).SingleOrDefault();
            return history;
        }

        public Trip GetTripByPersonalTripId(Guid personalTripId)
        {
            var personalTrip = dbContext.PersonalTrips.Include(pt=>pt.Trip).Where(t => t.PersonalTripId == personalTripId).SingleOrDefault();
            return personalTrip.Trip;
        }

        public IEnumerable<PersonalTrip> GetPersonalTripsByUserId(Guid userId)
        {
            var history = dbContext.PersonalTrips.Include(pt => pt.User).Where(h => h.User.UserId == userId).AsEnumerable();
            return history;
        }

    }
}
