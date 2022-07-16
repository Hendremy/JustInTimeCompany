using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    public class Booking
    {
        public int FlightId { get; set; }
        public Flight FlightInstance { get; set; }
        
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
