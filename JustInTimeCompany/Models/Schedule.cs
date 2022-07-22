using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display(Name ="Heure de décollage")]
        [DataType(DataType.DateTime)]
        public DateTime TakeOff { get; set; }
        [Display(Name = "Heure d'atterrissage")]
        [DataType(DataType.DateTime)]
        public DateTime Landing { get; set; }

        public Schedule()
        {

        }
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
