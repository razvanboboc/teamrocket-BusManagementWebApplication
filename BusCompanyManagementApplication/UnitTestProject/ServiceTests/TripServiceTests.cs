using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using BusCompanyManagement.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UnitTests.Services
{
    [TestClass]
    public class TripServiceTests
    {
        private Mock<IBusRepository> busRepoMock = new Mock<IBusRepository>();
        private Mock<ITripRepository> tripRepoMock = new Mock<ITripRepository>();
        private Guid existingBusId = Guid.Parse("71BC4766-B4DF-40DC-A084-134C153D2167");
        private Guid existingTripId = Guid.Parse("F3B878A2-9748-4EFC-966D-B125475C885C");
        private Trip _trip;

        [TestInitialize]
        public void InitializeTest()
        {

            var trip1 = new Trip
            {
                TripId = existingTripId,
                Arrival = "Craiova",
                Destination = "Bucuresti",
                ArrivalTime = new DateTime(2020, 5, 1, 8, 50, 10),
                DestinationTime = new DateTime(2020, 5, 1, 11, 50, 10)
            };



            var trip2 = new Trip
            {
                TripId = Guid.NewGuid(),
                Arrival = "Bacau",
                Destination = "Dabova",
            };

            var trip3 = new Trip
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Harnovesti",
            };

            var trips = new List<Trip>();
            trips.Add(trip1);
            trips.Add(trip2);

            var bus = new Bus
            {
                BusId = existingBusId,
                BusBrand = "Iveco",
                TotalSeats = 30,
                Trips = trips

            };

            var craiovaTrips = new List<Trip>();
            trips.Add(trip1);
            

            tripRepoMock.Setup(tripRepo => tripRepo.GetTripsByBusId(existingBusId))
                .Returns(trips);

            tripRepoMock.Setup(tripRepo => tripRepo.GetTripBy(existingTripId))
                           .Returns(trip1);

            tripRepoMock.Setup(tripRepo => tripRepo.GetTripsAccordingToFilters("Craiova" , "Bucuresti", new DateTime(2020, 5, 1, 8, 50, 10)))
                        .Returns(craiovaTrips);

            tripRepoMock.Setup(tripRepo => tripRepo.Delete(trip1));

            _trip = trip1;
        }

        [TestMethod]
        public void GetTripsByBusId_ThrowsException_WhenBusIdHasInvalidValue()
        {
            //arrange
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            var badBusId = "this is a bad bus id";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() =>
            {
                tripService.GetTripsByBusId(badBusId);
            });
        }

        [TestMethod]
        public void GetTripsByBusId_Returns_TripsWhenExist()
        {
            //arrange
            Exception throwException = null;
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            IEnumerable<Trip> trips = null;
            //act   
            try
            {
                trips = tripService.GetTripsByBusId(existingBusId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(trips);
        }

        [TestMethod]
        public void GetTripByBusId_ThrowsException_WhenBusDoesNotExist()
        {
            //arrange
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            var nonexistingBusId = "52803153-8E28-476D-9271-E6E40B634682";
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                tripService.GetTripsByBusId(nonexistingBusId);
            });

        }

        [TestMethod]
        public void GetTripBy_Returns_TripWhenExists()
        {
            //arrange
            Exception throwException = null;
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            Trip trip = null;
            //act   
            try
            {
                trip = tripService.GetTripBy(existingTripId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(trip);
        }

        [TestMethod]
        public void GetTripBy_ThrowsException_WhenTripIdHasInvalidValue()
        {
            //arrange
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            var badTripId = "this is a bad trip id";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                tripService.GetTripBy(badTripId);
            });

        }

        [TestMethod]
        public void GetTripBy_ThrowsException_WhenTripDoesNotExist()
        {
            //arrange
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            var nonexistingTripId = "014A9FAC-58F4-4B5C-A323-5E5391217B5D";
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                tripService.GetTripBy(nonexistingTripId);
            });

        }

        [TestMethod]
        public void GetTripsAccordingToFilters_Returns_TripsWhenExist()
        {
            //Arrange
            Exception throwException = null;
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);

            IEnumerable<Trip> trips = null;
            //act   
            try
            {
                trips = tripService.GetTripsAccordingToFilters("Craiova", "Bucuresti", new DateTime(2020, 5, 1, 8, 50, 10));
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(trips);
        }

        [TestMethod]
        public void AddTrip_ValidData_Return_OkResult()
        {
            //Arrange
            Exception throwException = null;
            var tripService = new TripsService(busRepoMock.Object, tripRepoMock.Object);
            var tripsThatWereCreated = new List<Trip>();
            var newTrip = new Trip { Arrival = "Gandacesti", Destination = "Craiova" };
            tripRepoMock.Setup(r => r.Add(It.IsAny<Trip>()))
                        .Callback((Trip newTrip) => tripsThatWereCreated.Add(newTrip));
            //Act
            try
            {
                tripService.AddTrip("Craiova", "Gandacesti", DateTime.Now, DateTime.Now);
            }
            catch (Exception e)
            {
                throwException = e;
            }

            
            // Asserts
            Assert.AreEqual(1, tripsThatWereCreated.Count());
            Assert.AreEqual("Craiova", tripsThatWereCreated.First().Destination);
        }

    }

}
