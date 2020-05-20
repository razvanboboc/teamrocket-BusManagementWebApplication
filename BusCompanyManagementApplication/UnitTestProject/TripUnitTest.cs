using BusCompanyManagement.ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusCompanyManagement.ApplicationLogic.UnitTests
{
    [TestClass]
    public class TripUnitTest
    {
        [TestMethod]
        public void GetBusBrandByDestination()
        {

            Bus bus = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Poncho",
                TotalSeats = 54,
            };

            Trip trip = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020,11,21,8,10,20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
                Bus = bus,
            };

            var busBrand = trip.GetBusBrandByDestination("Craiova");
            Assert.AreEqual("Poncho", busBrand);

            Bus bus2 = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Cartofel",
                TotalSeats = 54,
            };

            Trip trip2 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Dampas",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
                Bus = bus2,
            };

            var busBrand2 = trip2.GetBusBrandByDestination("Dampas");
            Assert.AreEqual("Cartofel", busBrand2);

            Bus bus3 = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Cartofel",
                TotalSeats = 54,
            };

            Trip trip3 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Diefel",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
                Bus = bus3,
            };

            var busBrand3 = trip3.GetBusBrandByDestination("Diefel");
            Assert.AreEqual("Cartofel", busBrand3);
        }

        [TestMethod]
        public void GetTravelTimeInHours()
        {
            Trip trip = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 5, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 8, 10, 20),             
            };

            var travelTime = trip.GetTravelTimeInHours(trip.DestinationTime, trip.ArrivalTime);

            Assert.AreEqual("3", travelTime);

            Trip trip2 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Bratovoiesti",
                Arrival = "Hartagonesti",
                DestinationTime = new DateTime(2020, 12, 21, 4, 10, 20),
                ArrivalTime = new DateTime(2020, 12, 21, 8, 10, 20),
            };

            var travelTime2 = trip2.GetTravelTimeInHours(trip2.DestinationTime, trip2.ArrivalTime);

            Assert.AreEqual("4", travelTime2);

            Trip trip3 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Oernd",
                Arrival = "Hemds",
                DestinationTime = new DateTime(2020, 12, 21, 3, 10, 20),
                ArrivalTime = new DateTime(2020, 12, 21, 8, 10, 20),
            };

            var travelTime3 = trip3.GetTravelTimeInHours(trip3.DestinationTime, trip3.ArrivalTime);

            Assert.AreEqual("5", travelTime3);
        }

        [TestMethod]
        public void GetTravelTimeInMinutes()
        {
            Trip trip = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 5, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 10, 10, 20),
            };

            var travelTime = trip.GetTravelTimeInMinutes(trip.DestinationTime, trip.ArrivalTime);

            Assert.AreEqual("300", travelTime);
        }

        [TestMethod]
        public void VerifyIfTripHasBusWithAirConditioning()
        {
            Bus bus = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Man",
                TotalSeats = 29,
                BusFacility = new BusFacility
                {
                    BusFacilityId = Guid.NewGuid(),
                    HasAirConditioning = "Da"
                }
            };

            Trip trip = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
                Bus = bus,
            };

            var answer = trip.VerifyIfTripHasBusWithAirConditioning();
            Assert.AreEqual(true, answer);
        }

        [TestMethod]
        public void ValidateChangeArrival()
        {
            Trip trip1 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            Trip trip2 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            Trip trip3 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Destination = "Craiova",
                Arrival = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            trip1.ChangeArrival("Boimanesti");
            Assert.AreEqual("Boimanesti", trip1.Arrival);

            trip2.ChangeArrival("Harmanesti");
            Assert.AreEqual("Harmanesti", trip2.Arrival);

            trip3.ChangeArrival("Blasmanesti");
            Assert.AreEqual("Blasmanesti", trip3.Arrival);

        }

        [TestMethod]
        public void ValidateChangeDestination()
        {
            Trip trip1 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            Trip trip2 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            Trip trip3 = new Trip()
            {
                TripId = Guid.NewGuid(),
                Arrival = "Craiova",
                Destination = "Bucuresti",
                DestinationTime = new DateTime(2020, 11, 21, 8, 10, 20),
                ArrivalTime = new DateTime(2020, 11, 21, 5, 10, 20),
            };

            trip1.ChangeDestination("Boimanesti");
            Assert.AreEqual("Boimanesti", trip1.Destination);

            trip2.ChangeDestination("Harmanesti");
            Assert.AreEqual("Harmanesti", trip2.Destination);

            trip3.ChangeDestination("Blasmanesti");
            Assert.AreEqual("Blasmanesti", trip3.Destination);

        }


    }

}
