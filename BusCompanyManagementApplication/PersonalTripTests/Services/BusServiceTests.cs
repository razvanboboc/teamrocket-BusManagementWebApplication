using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using BusCompanyManagement.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Services
{
    [TestClass]
    public class BusServiceTests
    {
        private Mock<IBusRepository> busRepoMock = new Mock<IBusRepository>();
        private Mock<ITripRepository> tripRepoMock = new Mock<ITripRepository>();
        private Guid existingBusId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA716");
        private Guid existingTripId = Guid.Parse("6D893D7A-4B1D-4A78-AF50-5D2540A6217F");
        private Bus _bus;

        [TestInitialize]
        public void InitializeTest()
        {

            var trip1 = new Trip
            {
                TripId = existingTripId,
                Arrival = "Craiova",
                Destination = "Bucuresti",
            };

            var trip2 = new Trip
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Botosani"
            
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

            busRepoMock.Setup(busRepo => busRepo.GetBusByTripId(existingTripId))
                            .Returns(bus);

            busRepoMock.Setup(busRepo => busRepo.GetBusByBusId(existingBusId))
                           .Returns(bus);

            busRepoMock.Setup(busRepo => busRepo.Delete(bus));      

            _bus = bus;
        }

        [TestMethod]
        public void GetBusByTripId_ThrowsException_WhenTripIdHasInvalidValue()
        {
            //arrange
            var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);

            var badTripId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                busService.GetBusByTripId(badTripId);
            });
        }

        //[TestMethod]
        //public void GetBusByTripId_ThrowsEntityNotFound_WhenTripDoesNotExist()
        //{
        //    //arrange
        //    var nonExistingTripId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
        //    var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);

        //    //act            
        //    //assert
        //    Assert.ThrowsException<EntityNotFoundException>(() => {
        //        busService.GetBusByTripId(nonExistingTripId);
        //    });
        //}

        [TestMethod]
        public void GetBusByTripId_Returns_BusWhenExists()
        {

            Exception throwException = null;
            var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);
            Bus bus = null;
            //act   
            try
            {
                bus = busService.GetBusByTripId(existingTripId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(bus);
        }

        [TestMethod]
        public void GetBusByBusId_ThrowsException_WhenBusIdHasInvalidValue()
        {
            //arrange
            var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);

            var badBusId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                busService.GetBusByBusId(badBusId);
            });
        }

        [TestMethod]
        public void GetBusByBusId_Returns_BusWhenExists()
        {

            Exception throwException = null;
            var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);
            Bus bus = null;
            //act   
            try
            {
                bus = busService.GetBusByBusId(existingBusId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(bus);
        }

        [TestMethod]
        public void DeleteBusByBusId_ThrowsException_WhenBusIdHasInvalidValue()
        {
            Exception throwException = null;
            var busService = new BusesService(busRepoMock.Object, tripRepoMock.Object);
           // Bus bus = null;

            //act   
            try
            {
                 busService.DeleteBus(existingBusId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
           // Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNull(_bus);
        }

    }
}
