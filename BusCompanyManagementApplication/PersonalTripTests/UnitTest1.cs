using BusCompanyManagement.ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PersonalTripTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateChangeStatus()
        {
            var personalTrip1 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "In progress"
            };
            Assert.AreEqual("In progress", personalTrip1.changeStatus("Done"));

            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "In progress"
            };
            Assert.AreEqual("Completed", personalTrip2.changeStatus("Completed"));

            var personalTrip3 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "Completed"
            };

            Assert.AreEqual("Completed", personalTrip3.changeStatus("Completed"));

            var personalTrip4 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
            };

            Assert.AreEqual("Completed", personalTrip4.changeStatus("Completed"));

            var personalTrip5 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
            };

            Assert.AreEqual(null, personalTrip5.changeStatus("Done"));

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

        [TestMethod]
        public void GetUserFirstNameByDestination()
        {
            var personalTrip1 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "In progress",
                User = new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Edison",
                    LastName = "Cavanni"
                },
                Trip = new Trip
                {
                    TripId = Guid.NewGuid(),
                    Arrival = "Craiova",
                    Destination = "Bucuresti",
                }
            };
            Assert.AreEqual("Edison", personalTrip1.GetUserFirstNameByDestinatiton("Bucuresti"));

            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "In progress",
                User = new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Edison",
                    LastName = "Cavanni"
                },
                Trip = new Trip
                {
                    TripId = Guid.NewGuid(),
                    Arrival = "Craiova",
                    Destination = "Bucuresti",
                }
            };
            Assert.AreEqual("Edison", personalTrip2.GetUserFirstNameByDestinatiton("Bucuresti"));
        }
    }
        
}
