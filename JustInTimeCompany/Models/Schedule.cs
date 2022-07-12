using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display(Name ="Heure de décollage")]
        public DateTime TakeOff { get; set; }
        [Display(Name = "Heure d'atterrissage")]
        public DateTime Landing { get; set; }

        public Schedule (DateTime takeOff, DateTime landing)
        {
            TakeOff = takeOff;
            Landing = landing;
        }
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
