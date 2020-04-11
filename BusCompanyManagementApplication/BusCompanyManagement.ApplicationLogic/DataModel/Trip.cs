using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public string Destination { get; set; }
        public string Arrival { get; set; }

        public DateTime DestinationTime { get; set; }

        public DateTime ArrivalTime { get; set; }
       
        //one-to-many Trip-Bus
        public Bus Bus { get; set; }
        //many-to-many Trip-Stop
        public ICollection<StoppingPoint> StoppingPoints { get; set; }
    }
}
