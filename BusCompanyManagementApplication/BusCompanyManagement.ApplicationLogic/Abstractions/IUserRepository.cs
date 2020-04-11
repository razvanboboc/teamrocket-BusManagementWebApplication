using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.Abstractions
{
    interface IUserRepository : IRepository<User>
    {
        User GetUserByPersonalTripId(Guid PersonalTripId);

        User GetUserByEmailAdress(String EmailAdress);

        User GetUserByFirstAndLastName(String FirstName, String LastName);

    }
}
