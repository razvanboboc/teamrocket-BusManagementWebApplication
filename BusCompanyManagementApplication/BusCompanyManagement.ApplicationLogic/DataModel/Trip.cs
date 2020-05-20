using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public string Destination { get; set; }
        public string Arrival { get; set; }

        public DateTime DestinationTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        //one-to-many Trip-Bus
        public Bus Bus { get; set; }
        //many-to-many Trip-Stop
        public ICollection<StoppingPoint> StoppingPoints { get; set; }

        public Trip() {
            StoppingPoints = new List<StoppingPoint>();
        }

        public string GetBusBrandByDestination(string destination)
        {
            if (this.Destination.Equals(destination))
            {
                return Bus.BusBrand;
            }
            return "";
        }

        public string GetTravelTimeInHours(DateTime destinationTime, DateTime arrivalTime)
        {
            if (this.DestinationTime.Equals(destinationTime) && this.ArrivalTime.Equals(arrivalTime))
            {
                TimeSpan travelTime = arrivalTime.Subtract(destinationTime);
                return travelTime.TotalHours.ToString();
            }
            return "";
        }

        public string GetTravelTimeInMinutes(DateTime destinationTime, DateTime arrivalTime)
        {
            if (this.DestinationTime.Equals(destinationTime) && this.ArrivalTime.Equals(arrivalTime))
            {
                TimeSpan travelTime = arrivalTime.Subtract(destinationTime);
                return travelTime.TotalMinutes.ToString();
            }
            return "";
        }

        public bool VerifyIfTripHasBusWithAirConditioning()
        {
            if (this.Bus.BusFacility.HasAirConditioning == "Da")
            {
                return true;
            }
            return false;
        }

        public void ChangeArrival(string arrival)
        {
            this.Arrival = arrival;
        }

        public void ChangeDestination(string destination)
        {
            this.Destination = destination;
        }

    }
}
