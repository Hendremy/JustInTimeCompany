using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    public class FlightInstance
    {
        public int Id { get; set; }

        public Flight Flight { get; set; }

        public Pilot Pilot { get; set; }

        public Aircraft Aircraft { get; set; }

        public Schedule Schedule { get; set; }

        public FlightReport FlightReport { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        [NotMapped]
        public int RemainingSeats => Aircraft.Capacity - Bookings.Count;

        [NotMapped]
        public DateTime Landing => Schedule.Landing;

        [NotMapped]
        public DateTime TakeOff => Schedule.TakeOff;
    }
}
