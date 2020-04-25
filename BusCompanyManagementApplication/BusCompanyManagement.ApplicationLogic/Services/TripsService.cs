using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Services
{
    public class TripsService
    {
        private IBusRepository busRepository;
        private ITripRepository tripRepository;
        

        public TripsService(IBusRepository busRepository, ITripRepository tripRepository)
        {
            this.busRepository = busRepository;
            this.tripRepository = tripRepository;
           
        }

        public Trip GetTripByArrival(string arrival)
        { 
            if (arrival == null)
            {
                throw new Exception("Null string");
            }

            return tripRepository.GetTripByArrival(arrival);
          
        }

        public Trip GetTripByDestination(string destination)
        {
            if (destination == null)
            {
                throw new Exception("Null string");
            }

            return tripRepository.GetTripByDestination(destination);
        }

        public IEnumerable<Trip> GetTrips()
        {
            return tripRepository.GetTrips();
        }


        //public Trip Add(Trip tripToBeAdded)
        //{
            
        //}

        //public bool Delete(Trip tripToBeDeleted)
        //{
            
        //}

        public IEnumerable<Trip> GetAll()
        {
            return tripRepository.GetAll();
        }



        //public Trip Update(T tripToUpdate)
        //{
            
        //}
    }
}
