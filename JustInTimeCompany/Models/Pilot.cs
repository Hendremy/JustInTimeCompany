namespace JustInTimeCompany.Models
{
    public class Pilot
    {
        public int Id { get; set; }

        public IEnumerable<Flight> FlightInstances;

        public JITCUser User { get; set; }

        public string FirstName => User.FirstName;

        public string LastName => User.LastName;

        public string FullName => User.FullName;

        public IEnumerable <Flight> GetCollidingFlights(Schedule sched)
        {
            return (from FlightInstance in FlightInstances
                    where
                    FlightInstance.Schedule.CollidesWith(sched)
                    select FlightInstance
                    );
        } 

        public bool IsAvailableForSchedule(Schedule sched)
        {
            return GetCollidingFlights(sched).Count() == 0;
        }
    }
}
