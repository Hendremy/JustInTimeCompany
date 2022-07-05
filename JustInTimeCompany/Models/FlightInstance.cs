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

        public int RemainingSeats => Aircraft.Capacity - Bookings.Count;

        public DateTime Landing => Schedule.Landing;

        public DateTime TakeOff => Schedule.TakeOff;
    }
}
