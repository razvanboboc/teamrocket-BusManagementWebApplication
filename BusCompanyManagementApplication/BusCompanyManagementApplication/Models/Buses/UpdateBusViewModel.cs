using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Models.Buses
{
    public class UpdateBusViewModel
    {
        public string BusBrand { get; set; }
        public int TotalSeats { get; set; }
        public Guid BusId { get; set; }
    }
}
