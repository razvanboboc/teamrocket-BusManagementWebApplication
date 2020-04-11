using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{

    public class PersonalTrip
    {
        public Guid PersonalTripId { get; set; }
        public string Status { get; set; }
        public int TicketPrice { get; set; }
        public int SeatNumber { get; set; }
        public int Rating { get; set; }
       
        //one-to-one PersonaTrip-Trip
        public Trip Trip { get; set; }
    }
}
