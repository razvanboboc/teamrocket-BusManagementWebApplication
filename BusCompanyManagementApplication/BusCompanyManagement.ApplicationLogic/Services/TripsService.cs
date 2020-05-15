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

        public IEnumerable<Trip> GetTripsByArrival(string arrival)
        { 
            if (arrival == null)
            {
                throw new Exception("Null string");
            }

            return tripRepository.GetTripsByArrival(arrival);
          
        }

        public IEnumerable<Trip> GetTripsByDestination(string destination)
        {
            if (destination == null)
            {
                throw new Exception("Null string");
            }

            return tripRepository.GetTripsByDestination(destination);
        }

        public IEnumerable<Trip> GetTripsAccordingToFilters(string arrival, string destination, DateTime arrivalTime)
        {
            if (arrival == null && destination == null && arrivalTime == null)
            {
                throw new Exception("Null parameters");
            }

            return tripRepository.GetTripsAccordingToFilters(arrival, destination, arrivalTime);
        }
        public IEnumerable<Trip> GetTrips()
        {
            return tripRepository.GetTrips();
        }



        public IEnumerable<Trip> GetAll()
        {
            return tripRepository.GetAll();

        }

        //Add trip
        public void AddTrip (string destination, string arrival, DateTime arrivalTime, DateTime destinationTime)
        {

            tripRepository.Add(new Trip() { TripId = Guid.NewGuid(), Arrival = arrival, Destination = destination,
                                            ArrivalTime = arrivalTime, DestinationTime = destinationTime});
        }

        //Remove trip
        public void RemoveTrip(string tripId)
        {
            Guid tripIdGuid = Guid.Empty;
            if (!Guid.TryParse(tripId, out tripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var trip = tripRepository.GetTripBy(tripIdGuid);
            tripRepository.Delete(trip);
        }

        public void DeleteTrip(Guid tripId)
        {
            var trip = tripRepository.GetTripBy(tripId);
            tripRepository.Delete(trip);
        }

        public void UpdateTrip(Guid tripId, string destination, string arrival, DateTime arrivalTime, DateTime destinationTime)
        {
            //Guid tripIdGuid = Guid.Empty;
            //if (!Guid.TryParse(tripId, out tripIdGuid))
            //{
            //    throw new Exception("Invalid Guid Format");
            //}

            var trip = tripRepository.GetTripBy(tripId);
            trip.Arrival = arrival;
            trip.Destination= destination;
            trip.ArrivalTime = arrivalTime;
            trip.DestinationTime = destinationTime;
            tripRepository.Update(trip);
        }
    }
}
