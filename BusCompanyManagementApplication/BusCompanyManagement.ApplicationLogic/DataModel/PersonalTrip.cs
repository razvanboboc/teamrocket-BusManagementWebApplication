using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.ApplicationLogic.DataModel
{

    public class PersonalTrip
    {
        public Guid PersonalTripId { get; set; }
        public string Status { get; set; }
        public int TicketPrice { get; set; }
        public int SeatNumber { get; set; }
        public int Rating { get; set; }
        //one-to-many User-PersonalTrip 
        public User User { get; set; }
        //one-to-one PersonaTrip-Trip
        public Trip Trip { get; set; }

        public PersonalTrip()
        {
            
        }
        
        public string changeStatus(string status)
        {
            if (status.Equals("In progress") || status.Equals("Completed") || status == null)
            {
                Status = status;
            }
            return Status;
        }

        public int changeRating(int rating)
        {
            if (rating >= 0 && rating <= 5)
            {
                Rating = rating;
            }
            return Rating;
        }

        public string GetUserFirstNameByDestinatiton(string destination)
        {
            if (Trip.Destination.Equals(destination))
            {
                return User.FirstName;
            }
            return "";
        }
    }
}
