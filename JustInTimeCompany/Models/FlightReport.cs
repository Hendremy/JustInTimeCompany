using System.ComponentModel.DataAnnotations.Schema;

namespace JustInTimeCompany.Models
{
    public class FlightReport
    {
        public int Id { get; set; }
        public int FlightInstanceId { get; set; }
        public FlightInstance FlightInstance { get; set; }
        public Schedule ActualSchedule { get; set; }

        [NotMapped]
        public double Delay => (ActualSchedule.Landing - FlightInstance.Landing).TotalMinutes;
        
        public string? DelayJustification { get; set; }
    }
}
