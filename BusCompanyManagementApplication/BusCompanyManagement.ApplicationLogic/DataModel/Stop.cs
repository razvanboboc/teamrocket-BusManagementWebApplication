using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Stop
    {
        public Guid StopId { get; set; }
        public string LocationName { get; set; }
        public DateTime StopDuration { get; set; }
        public string TouristicPoints { get; set; }
        //many-to-many Trip-Stop
        public ICollection<StoppingPoint> StoppingPoints { get; set; }
    }
}
