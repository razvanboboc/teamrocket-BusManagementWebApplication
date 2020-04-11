using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Bus
    {
        public string BusBrand { get; set; }
        public Guid BusId { get; set; }
        public int TotalSeats { get; set; }
        //one-to-one Bus-BusFacility
        public BusFacility BusFacility { get; set; }
        //one-to-many Bus-AvailableSeat hatz
        public ICollection<AvailableSeat> AvailableSeats { get; set; }
        //one-to-many Bus-Trip 
        public ICollection<Trip> Trips { get; set; }
    }
}
