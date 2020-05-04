using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.TripModel
{
    public class BusInfoViewModel
    {
        public Bus Bus { get; set; }
        public string BusBrand { get; set; }
        public int TotalSeats { get; set; }

        //public BusFacility BusFacility { get; set; }
        //public ICollection<AvailableSeat> AvailableSeats { get; set; }
    }
}
