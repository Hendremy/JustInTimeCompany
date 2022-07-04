namespace JustInTimeCompany.Models
{
    public class FlightReport
    {

        public FlightInstance FlightInstance { get; set; }
        public Schedule ActSchedule { get; set; }

        public double Delay => (ActSchedule.Landing - FlightInstance.Schedule.Landing).TotalMinutes;
        
        public string DelayJustification { get; set; }
    }
}
