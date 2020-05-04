using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Services
{
    public class UsersService
    {
        private IUserRepository userRepository;
       
        //should contain an addition method. 

        public UsersService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
      

        }

        public void AddUser(string userId, string email, string password )
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            userRepository.Add(new User() { UserId = userIdGuid, EmailAdress = email, Password = password});
        }


        /*
        public void AddTripInHistory(string tripId, string personalTripId, string status, int ticketPrice, int seatNumber, int rating)
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
            historyTripRepository.Add(new PersonalTrip() { PersonalTripId = Guid.NewGuid(), Status = status, TicketPrice = ticketPrice, SeatNumber = seatNumber, Rating = rating });
        }
        */
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

    }
}
