using JustInTimeCompany.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany.Models
{
    [BookPositiveSeatsAttribute(ErrorMessage ="Le nombre de places doit être supérieur ou égal à 1")]
    [RemainingSeatsAttribute]

    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name="Places réservées")]
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
