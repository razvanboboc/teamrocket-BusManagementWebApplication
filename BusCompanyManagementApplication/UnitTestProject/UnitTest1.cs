using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagement.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ValidateStatus()
        {
            var personalTrip1 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "In progress"
            };
            Assert.AreEqual(true, personalTrip1.IsStatusValid());
            
            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "Completed"
            };
            Assert.AreEqual(true, personalTrip2.IsStatusValid());

            var personalTrip3 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            Assert.AreEqual(false, personalTrip3.IsStatusValid());
        }

        [TestMethod]
        public void ValidateChangeRating()
        {
            var personalTrip1 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "In progress"
            };
            Assert.AreEqual(3, personalTrip1.changeRating(9999));

            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "Completed"
            };
            Assert.AreEqual(3, personalTrip2.changeRating(-9999));

            var personalTrip3 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            Assert.AreEqual(0, personalTrip3.changeRating(0));

            var personalTrip4 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            Assert.AreEqual(5, personalTrip4.changeRating(5));

            var personalTrip5 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            Assert.AreEqual(2, personalTrip5.changeRating(2));


            var personalTrip6 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 2,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            Assert.AreEqual(2, personalTrip6.changeRating(2));
        }
    }
}
