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

        public Bus GetBusByBusId(string busId)
        {
            Guid busIdGuid = Guid.Empty;
            if (!Guid.TryParse(busId, out busIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return busRepository.GetBusByBusId(busIdGuid);
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
            // GetTripByBusID
            busRepository.Add(new Bus() { BusId = Guid.NewGuid(), BusBrand = busBrand, TotalSeats = totalSeats});
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

        public void DeleteBus(Guid busId)
        {
            var bus = busRepository.GetBusByBusId(busId);
            busRepository.Delete(bus);
        }

        public void UpdateBus(Guid busId, string busBrand, int totalSeats)
        {
            var bus = busRepository.GetBusByBusId(busId);
            bus.BusBrand = busBrand;
            bus.TotalSeats = totalSeats;
            busRepository.Update(bus);
        }

    }
}
