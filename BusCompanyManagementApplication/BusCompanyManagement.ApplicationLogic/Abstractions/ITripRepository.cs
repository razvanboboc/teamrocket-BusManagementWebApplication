using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Abstractions
{
    public interface ITripRepository : IRepository<Trip>
    {
        Trip GetTripBy(Guid tripId);
        Trip GetTripByDestination(string destination); // remove
        Trip GetTripByArrival(string arrival); //remove
    }
       
}
