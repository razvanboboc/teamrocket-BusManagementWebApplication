using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.TripModel
{
    public class BuyTicketViewModel
    {
        public Guid TripId { get; set; }
        public int SeatNumber { get; set; }
    }
}
