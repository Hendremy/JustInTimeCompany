namespace JustInTimeCompany.Models
{
    public class Pilot
    {
        public int Id { get; set; }

        public ICollection<Flight> FlightInstances;

        public string UserId { get; set; }
        public JITCUser User { get; set; }

        public string FirstName => User.FirstName;

        public string LastName => User.LastName;

        public string FullName => User.FullName;

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
