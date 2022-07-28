using JustInTimeCompany.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    [BookPositiveSeats(ErrorMessage ="Le nombre de places doit être supérieur ou égal à 1")]
    [RemainingSeats(ErrorMessage ="Le nombre de places voulu n'est plus disponible")]

    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name="Places réservées")]
        public int SeatsTaken { get; set; }
        public Booking()
        {

        }

        public Booking(Flight flight, Customer customer)
        {
            Flight = flight;
            Customer = customer;
        }

        public bool IsPassed() => Flight.IsPassed();

        public bool NeedsPayments() => (Flight.TakeOff - DateTime.Now).TotalHours <= 24;

    }
}
