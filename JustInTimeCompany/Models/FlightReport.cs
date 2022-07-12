using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    public class FlightReport
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public Schedule ActualSchedule { get; set; }

        [NotMapped]
        public double Delay => (ActualSchedule.Landing - Flight.Landing).TotalMinutes;
        
        public string? DelayJustification { get; set; }

        public FlightReport()
        {

        }

        public FlightReport(Flight flight)
        {
            ActualSchedule = new Schedule(flight.TakeOff, flight.Landing);
            Flight = flight;
        }
    }
}
