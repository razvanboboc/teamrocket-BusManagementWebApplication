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
            var history = dbContext.PersonalTrips.Where(h => h.User.UserId == userId).FirstOrDefault();
            return history;
        }

        public Trip GetTripByPersonalTripId(Guid personalTripId)
        {
            var personalTrip = dbContext.PersonalTrips.Include(pt=>pt.Trip)
                                                       .Include(pt => pt.User)
                                                       .Where(t => t.PersonalTripId == personalTripId).FirstOrDefault();
            return personalTrip.Trip;
        }

        public IEnumerable<PersonalTrip> GetPersonalTripsByUserId(Guid userId)
        {
            var history = dbContext.PersonalTrips.Include(pt => pt.User)
                                                    .Include(pt => pt.Trip)
                                                    .Where(h => h.User.UserId == userId)                                                   
                                                    .AsEnumerable();

            List<PersonalTrip> listDone = new List<PersonalTrip>();
            List<PersonalTrip> listUndone = new List<PersonalTrip>();


            foreach (var item in history)
            {
                if (item.Trip.DestinationTime < DateTimeOffset.Now)
                {
                    item.Status = "Completed";
                    listDone.Add(item);
                }
                else
                {
                    item.Status = "In progress";
                    listUndone.Add(item);
                }
            }
            dbContext.SaveChanges();

            listUndone.Sort((pt1, pt2) => pt1.Trip.ArrivalTime.CompareTo(pt2.Trip.ArrivalTime));
            listDone.Sort((pt1, pt2) => -pt1.Trip.ArrivalTime.CompareTo(pt2.Trip.ArrivalTime));

            return listUndone.Concat(listDone);
        }
        //
        public PersonalTrip GetPersonalTripByUserId(Guid userId, Guid personalTripId)
        {
            var personalTrip = dbContext.PersonalTrips.Include(pt => pt.User)
                                                    .Include(pt => pt.Trip)
                                                    .Where(h => h.User.UserId == userId && h.PersonalTripId == personalTripId).SingleOrDefault();
                                                    
            return personalTrip;
        }        
    }
}
