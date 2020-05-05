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
        
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }
    }
}
