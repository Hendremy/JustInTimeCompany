using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SeatsTaken { get; set; }

        [NotMapped]
        public bool IsPassed => Flight.IsPassed;

        public Booking()
        {

        }
        public Booking(Flight flight, Customer customer)
        {
            Flight = flight;
            Customer = customer;
        }
    }
}
