using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class User
    {
        public Guid UserId { get; set; }
        //test Paul
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        
        public string DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //One-to-many User-PersonalTrip
        public ICollection<PersonalTrip> PersonalTrip { get; set; }
    }
}
