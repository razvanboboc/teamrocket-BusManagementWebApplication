using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Services
{
    public class AnnouncementsService
    {
        private IAnnouncementRepository announcementRepository;

        public AnnouncementsService(IAnnouncementRepository announcementRepository)
        {
            this.announcementRepository = announcementRepository;
        }

        public Announcement GetAnnouncementById(Guid id)
        {
            var announcement = announcementRepository.GetAnnouncementById(id);

            return announcement;

        }

        public IEnumerable<Announcement> GetAll()
        {
            var announcements = announcementRepository.GetAll();
            return announcements;
        }
    }
}
