using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(BusCompanyManagementDbContext dbContext) : base(dbContext)
        {

        }

        public User GetUserBy(Guid personalTripId)
        {
            var user = dbContext.Users.Where(u => u.PersonalTrip.Any(p => p.PersonalTripId == personalTripId)).SingleOrDefault();
            return user;
        }

        public User GetUserByEmailAdress(string emailAdress)
        {
            var user = dbContext.Users.Where(u => u.EmailAdress == emailAdress).SingleOrDefault();
            return user;
        }

        public User GetUserByFirstAndLastName(string firstName, string lastName)
        {
            var user = dbContext.Users.Where(u => u.FirstName == firstName && u.LastName == lastName).SingleOrDefault();
            return user;
        }
       

    }
}
