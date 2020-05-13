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
            personalTrip1.changeStatus("Done");
            Assert.AreEqual("In progress", personalTrip1.Status);

            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "In progress"
            };
            personalTrip2.changeStatus("Completed");
            Assert.AreEqual("Completed", personalTrip2.Status);

            var personalTrip3 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
                Status = "Completed"
            };

            personalTrip3.changeStatus("Completed");

            Assert.AreEqual("Completed", personalTrip3.Status);

            var personalTrip4 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
            };

            personalTrip4.changeStatus("Completed");

            Assert.AreEqual("Completed", personalTrip4.Status);

            var personalTrip5 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 23,
                TicketPrice = 132,
            };
            personalTrip5.changeStatus("Done"); 

            Assert.AreEqual(null, personalTrip5.Status);

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
            personalTrip1.changeRating(9999);
            Assert.AreEqual(3, personalTrip1.Rating);

            var personalTrip2 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "Completed"
            };
            personalTrip2.changeRating(-9999);
            Assert.AreEqual(3, personalTrip2.Rating);

            var personalTrip3 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };

            personalTrip3.changeRating(0);
            Assert.AreEqual(0, personalTrip3.Rating);

            var personalTrip4 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };
            personalTrip4.changeRating(5);
            Assert.AreEqual(5, personalTrip4.Rating);

            var personalTrip5 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 3,
                TicketPrice = 132,
                Status = "dadafa232as"
            };
            personalTrip5.changeRating(2);
            Assert.AreEqual(2, personalTrip5.Rating);


            var personalTrip6 = new PersonalTrip()
            {
                PersonalTripId = Guid.NewGuid(),
                Rating = 2,
                TicketPrice = 132,
                Status = "dadafa232as"
            };
            personalTrip6.changeRating(2);
            Assert.AreEqual(2, personalTrip6.Rating);
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
