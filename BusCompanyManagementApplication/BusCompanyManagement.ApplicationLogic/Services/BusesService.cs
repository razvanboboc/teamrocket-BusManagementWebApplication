using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Services
{
    public class BusesService
    {
        private IBusRepository busRepository;
        private ITripRepository tripRepository;

        public BusesService(IBusRepository busRepository, ITripRepository tripRepository)
        {
            this.busRepository = busRepository;
            this.tripRepository = tripRepository;
        }
        public Bus GetBusByTripId(string tripId)
        {
            Guid tripIdGuid = Guid.Empty;
            if (!Guid.TryParse(tripId, out tripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
         
            return busRepository.GetBusByTripId(tripIdGuid);
        }


        public IEnumerable<Bus> GetBuses()
        {
            return busRepository.GetBuses();
        }

        //Add bus
        public void AddBus(string tripId, string busBrand, int totalSeats)
        {
            Guid tripIdGuid = Guid.Empty;
            if (!Guid.TryParse(tripId, out tripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
         
            busRepository.Add(new Bus() { BusId = Guid.NewGuid(), BusBrand = busBrand, TotalSeats = totalSeats });
        }

        //Remove bus
        public void RemoveBus(string tripId)
        {
            Guid tripIdGuid = Guid.Empty;
            if (!Guid.TryParse(tripId, out tripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var bus = busRepository.GetBusByTripId(tripIdGuid);
            busRepository.Delete(bus);
        }
    }
}
