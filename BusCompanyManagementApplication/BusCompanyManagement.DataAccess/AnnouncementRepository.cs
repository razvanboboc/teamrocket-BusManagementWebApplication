using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }
        public Announcement GetAnnouncementById(Guid id)
        {
            var announcement = dbContext.Announcements.Where(a => a.AnnouncementId == id).SingleOrDefault();

            return announcement;
        }

       
    }
}
