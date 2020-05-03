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

    
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

    }
}
