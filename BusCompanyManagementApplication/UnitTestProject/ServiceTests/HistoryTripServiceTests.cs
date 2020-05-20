using BusCompanyManagement.ApplicationLogic.Abstractions;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Exceptions;
using BusCompanyManagement.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.ServiceTests
{
    [TestClass]
    public class HistoryTripServiceTests
    {
        private Mock<ITripRepository> tripRepoMock = new Mock<ITripRepository>();
        private Mock<IHistoryTripRepository> historyTripRepoMock = new Mock<IHistoryTripRepository>();
        private Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();
        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
        private Guid existingPersonalTripId = Guid.Parse("9299FFCC-435E-4A6D-99DF-57A4D6FBA719");

        [TestInitialize]
        public void InitializeTest()
        {
            var aUser = new User
            {
                UserId = existingUserId,
                FirstName = "Mihai"
            };

            var aTrip = new Trip
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Bucuresti"
            };

            var historyTrip = new PersonalTrip
            {
                PersonalTripId = existingPersonalTripId,
                Rating = 5,
                SeatNumber = 12,
                TicketPrice = 122,
                User = aUser,
                Trip = aTrip
            };

            historyTripRepoMock.Setup(historyTripRepo => historyTripRepo.GetPersonalTripByUserId(existingUserId))
                                                                        .Returns(historyTrip);
            historyTripRepoMock.Setup(historyTripRepo => historyTripRepo.GetTripByPersonalTripId(existingPersonalTripId))
                                                                        .Returns(aTrip);
        }

        [TestMethod]
        public void GetHistoryTripByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange            
            var historyTripsService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);

            var badUserId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                historyTripsService.GetPersonalTripByUserId(badUserId);
            });
        }

        [TestMethod]
        public void GetHistoryTripByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            var historyTripService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                historyTripService.GetPersonalTripByUserId(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetHistoryTripByUserId_Returns_UserWhenExists()
        {

            Exception throwException = null;
            var teacherService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);
            PersonalTrip user = null;
            //act   
            try
            {
                user = teacherService.GetPersonalTripByUserId(existingUserId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetTripByPersonalTripId_ThrowsException_WhenPersonalTripIdHasInvalidValue()
        {
            //arrange            
            var historyTripsService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);

            var badPersonalTripId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                historyTripsService.GetTripByPersonalTripId(badPersonalTripId);
            });
        }

        [TestMethod]
        public void GetTripByPersonalTripId_ThrowsEntityNotFound_WhenPersonalTripIdDoesNotExist()
        {
            //arrange
            var nonExistingPersonalTripId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            var historyTripService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                historyTripService.GetTripByPersonalTripId(nonExistingPersonalTripId);
            });
        }

        [TestMethod]
        public void GetTripByPersonalTripId_Returns_TripWhenExists()
        {
            Exception throwException = null;
            var teacherService = new HistoryTripsService(tripRepoMock.Object, userRepoMock.Object, historyTripRepoMock.Object);
            Trip aTrip = null;
            //act   
            try
            {
                aTrip = teacherService.GetTripByPersonalTripId(existingPersonalTripId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(aTrip);
        }
    }
}
