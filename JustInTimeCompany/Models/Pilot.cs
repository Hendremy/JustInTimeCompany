namespace JustInTimeCompany.Models
{
    public class Pilot : JITCUser
    {
        public ICollection<FlightInstance> FlightInstances;
    }
}
