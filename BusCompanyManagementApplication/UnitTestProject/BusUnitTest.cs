using BusCompanyManagement.ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class BusUnitTest
    {
        [TestMethod]
        public void GetNrOfFreeSeats()
        {
            var availableSeats = new List<AvailableSeat>
            {
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
            };

            Bus bus = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Iveco",
                TotalSeats = 25,
                AvailableSeats = availableSeats
            };

            var numOfFreeSeats = bus.GetNumberOfFreeSeats();
            Assert.AreEqual(3, numOfFreeSeats);
        }

        [TestMethod]
        public void GetNrOfOccupiedSeats()
        {
            var availableSeats = new List<AvailableSeat>
            {
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
            };

            Bus bus = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Man",
                TotalSeats = 29,
                AvailableSeats = availableSeats
            };

            var numOfOccupiedSeats = bus.GetNumberOfOccupiedSeats();
            Assert.AreEqual(4, numOfOccupiedSeats);
        }

        [TestMethod]
        public void hasAtLeast5FreeSeatsOnDestination()
        {
            var availableSeats = new List<AvailableSeat>
            {
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
            };

            var availableSeats1 = new List<AvailableSeat>
            {
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Free"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
                new AvailableSeat {AvailableSeatId = Guid.NewGuid(), Status = "Occupied"},
            };

            Bus bus = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Iveco",
                TotalSeats = 45,
                AvailableSeats = availableSeats
            };

            Bus bus1 = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Man",
                TotalSeats = 509,
                AvailableSeats = availableSeats1
            };


            var trips = new List<Trip>
            {
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Arad", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Brasov", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Deva", Bus = bus1},
            };

            bus.Trips = trips;
            bus1.Trips = trips;
            bool hasAtLeast5FreeSeatsOnDestinations = bus.hasAtLeast5FreeSeatsOnDestination("Bucuresti");
            Assert.AreEqual(true, hasAtLeast5FreeSeatsOnDestinations);
        }

        [TestMethod]
        public void tripsWithBusesWithAirConditioning()
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

            Bus bus1 = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Iveco",
                TotalSeats = 29,
                BusFacility = new BusFacility
                {
                    BusFacilityId = Guid.NewGuid(),
                    HasAirConditioning = "Nu"
                }
            };

            Bus bus2 = new Bus()
            {
                BusId = Guid.NewGuid(),
                BusBrand = "Scania",
                TotalSeats = 34,
                BusFacility = new BusFacility
                {
                    BusFacilityId = Guid.NewGuid(),
                    HasAirConditioning = "Da"
                }
            };

            var trips = new List<Trip>
            {
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Arad", Bus = bus},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Brasov", Bus = bus1},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Bucuresti", Bus = bus2},
                new Trip {TripId = Guid.NewGuid(), Arrival = "Craiova", Destination = "Deva", Bus = bus2},
            };

            bus.Trips = trips;
            var tripss =  bus.tripsWithBusesWithAirConditioning();
            Assert.AreEqual(true, tripss.All(t => t.Bus.BusFacility.HasAirConditioning == "Da"));
        }
    }
}
