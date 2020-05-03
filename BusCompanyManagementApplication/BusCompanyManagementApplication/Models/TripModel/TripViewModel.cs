using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.TripModel
{
    public class TripViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }
    }
}
