using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Bus
    {
        public string BusBrand { get; set; }
        public Guid BusId { get; set; }
        public int TotalSeats { get; set; }
        //one-to-one Bus-BusFacility
        public BusFacility BusFacility { get; set; }
        //one-to-many Bus-AvailableSeat hatz
        public ICollection<AvailableSeat> AvailableSeats { get;  set; }
        //one-to-many Bus-Trip 
        public ICollection<Trip> Trips { get;  set; }

        public Bus()
        {
            AvailableSeats = new List<AvailableSeat>();
            Trips = new List<Trip>();
        }

        public int GetNumberOfFreeSeats()
        {
            int numberOfFreeSeats = 0;

            foreach (var seat in AvailableSeats)
            {
                if (seat.Status == "Free")
                {
                    numberOfFreeSeats++;
                }
            }

            return numberOfFreeSeats;
        }

        public int GetNumberOfOccupiedSeats()
        {
            return AvailableSeats.Count - GetNumberOfFreeSeats();
        }

        public bool hasAtLeast5FreeSeatsOnDestination(string destination)
        {
                var trips = Trips.Where(d => d.Destination == destination);

                foreach(var trip in trips)
                {
                    if(trip.Bus.GetNumberOfFreeSeats() >= 5)
                    {
                        return true;
                    } 
                }
                return false;                
        }

        public IReadOnlyCollection<Trip> tripsWithBusesWithAirConditioning()
        {
            var tripList = new List<Trip>();
            foreach(var trip in Trips)
            {
               if(trip.Bus.BusFacility.HasAirConditioning == "Da")
               {
                    tripList.Add(trip);
               }     
            }
            return tripList;
        }


    }
}

