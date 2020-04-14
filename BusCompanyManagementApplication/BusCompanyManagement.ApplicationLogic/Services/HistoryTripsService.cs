using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Services
{
    public class HistoryTripsService
    {
        private ITripRepository tripRepository;
        private IUserRepository userRepository;
        private IHistoryTripRepository historyTripRepository;

        public HistoryTripsService(ITripRepository tripRepository, IUserRepository userRepository, IHistoryTripRepository historyTripRepository)
        {
            this.tripRepository = tripRepository;
            this.historyTripRepository = historyTripRepository;
            this.userRepository = userRepository;
        }


        public IEnumerable<PersonalTrip> GetTripHistoryByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
                   
            return historyTripRepository.GetPersonalTripsByUserId(userIdGuid);                                       
        }

        public PersonalTrip GetPersonalTripByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }            

            var personaltrip = historyTripRepository.GetHistoryTripByUserId(userIdGuid);
            if (personaltrip == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return personaltrip;
        }

        public Trip GetTripByPersonalTripId(string personalTripId)
        {
            Guid personalTripIdGuid = Guid.Empty;
            if (!Guid.TryParse(personalTripId, out personalTripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var trip = historyTripRepository.GetTripByPersonalTripId(personalTripIdGuid);
            if (trip == null)
            {
                throw new EntityNotFoundException(personalTripIdGuid);
            }

            return trip;
        }

        public void AddTripInHistory(string tripId, string personalTripId, string status, int ticketPrice, int seatNumber, int  rating)
        {
            Guid tripIdGuid = Guid.Empty;
            if (!Guid.TryParse(tripId, out tripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            Guid personalTripIdGuid = Guid.Empty;
            if (!Guid.TryParse(personalTripId, out personalTripIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var trip = tripRepository.GetTripBy(tripIdGuid);
            var user = userRepository.GetUserBy(personalTripIdGuid);

            if (trip == null)
            {
                throw new EntityNotFoundException(tripIdGuid);
            }

            if (user == null)
            {
                throw new EntityNotFoundException(personalTripIdGuid);
            }
            historyTripRepository.Add(new PersonalTrip() { PersonalTripId = Guid.NewGuid(), Status = status, TicketPrice = ticketPrice, SeatNumber = seatNumber, Rating = rating});
        }

        public void RemoveHistoryTrip(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var historyTrip = historyTripRepository.GetHistoryTripByUserId(userIdGuid);
            historyTripRepository.Delete(historyTrip);
        }


    }
}
