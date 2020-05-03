using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.HistoryTrip
{
    public class AddTripInHistoryViewModel
    {
        public string Status { get; set; }
        public int TicketPrice { get; set; }
        public int SeatNumber { get; set; }
        public int Rating { get; set; }
    }
}
