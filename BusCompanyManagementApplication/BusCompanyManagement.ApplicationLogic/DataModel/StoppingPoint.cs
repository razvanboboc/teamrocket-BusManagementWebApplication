using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class StoppingPoint
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public Guid StopId { get; set; }
        public Stop Stop { get; set; }
    }
}
