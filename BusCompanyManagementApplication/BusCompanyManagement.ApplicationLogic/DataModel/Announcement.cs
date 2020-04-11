using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Announcement
    {
        public Guid AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
