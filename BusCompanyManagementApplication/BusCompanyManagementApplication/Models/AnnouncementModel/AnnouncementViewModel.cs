using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.AnnouncementModel
{
    public class AnnouncementViewModel
    {
        public IEnumerable<Announcement> Announcements { get; set; }
    }
}
