namespace JustInTimeCompany.Models
{
    public class Pilot : JITCUser
    {
        public ICollection<FlightInstance> FlightInstances;

        public bool IsAvailableForSchedule(Schedule sched)
        {
            return (from FlightInstance in FlightInstances
                    where
                    FlightInstance.Schedule.CollidesWith(sched)
                    select FlightInstance
                    ).Count() == 0;
        }
    }
}
