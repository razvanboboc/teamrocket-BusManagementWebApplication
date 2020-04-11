using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class BusFacility
    {
        public Guid BusFacilityId { get; set; }
        public string HasTv { get; set; }
        public string HasAirConditioning { get; set; }
        public string HasBabyChair { get; set; }
        //one-to-one Bus-BusFacility
        public Guid BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
