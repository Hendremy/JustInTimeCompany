namespace JustInTimeCompany.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime TakeOff { get; set; }
        public DateTime Landing { get; set; }

        public bool TimeIsInBetween(DateTime time)
        {
            return time < TakeOff && Landing < time;
        }

        public bool CollidesWith(Schedule sched)
        {
            return TimeIsInBetween(sched.TakeOff) || TimeIsInBetween(sched.Landing);
        }
    }
}
