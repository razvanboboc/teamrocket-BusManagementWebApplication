using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserBy(Guid personalTripId);

        User GetUserByEmailAdress(String emailAdress); //remove

        User GetUserByFirstAndLastName(String firstName, String lastName); //remove
         
    }
}
