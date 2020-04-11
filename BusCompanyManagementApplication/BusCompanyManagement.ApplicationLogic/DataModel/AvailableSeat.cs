using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class AvailableSeat
    {
        public Guid AvailableSeatId { get; set; }
        public string Status { get; set; }
        //one-to-many Bus-AvailableSeat
        public Bus Bus { get; set; }
    }
}
