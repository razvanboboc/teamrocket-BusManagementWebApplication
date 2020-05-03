using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.TripModel
{
    public class UpdateTripViewModel
    {
        public Guid TripId { get; set; }
        public string Destination { get; set; }
        public string Arrival { get; set; }

        public DateTime DestinationTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
