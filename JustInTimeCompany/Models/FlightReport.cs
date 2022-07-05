namespace JustInTimeCompany.Models
{
    public class FlightReport
    {

        public FlightInstance FlightInstance { get; set; }
        public Schedule ActualSchedule { get; set; }

        public double Delay => (ActualSchedule.Landing - FlightInstance.Landing).TotalMinutes;
        
        public string DelayJustification { get; set; }
    }
}
