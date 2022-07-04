namespace JustInTimeCompany.Models
{
    public class FlightInstance
    {
        public int Id { get; set; }

        public Flight Flight { get; set; }

        public Pilot Pilot { get; set; }

        public Aircraft Aircraft { get; set; }

        public DateTime? ActualTakeOff { get; set; }

        public DateTime? ActualLanding { get; set; }

        public string? DelayJustification { get; set; }

        public bool GotDelayed => (Flight.Landing - ActualLanding).Value.TotalMinutes > 10;

        public ICollection<Booking> Bookings { get; set; }

        public int RemainingSeats => Aircraft.PassengerCapacity - Bookings.Count;
    }
}
