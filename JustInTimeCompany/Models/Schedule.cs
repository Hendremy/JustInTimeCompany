using JustInTimeCompany.Validations;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display(Name = "Décollage")]
        [DataType(DataType.DateTime)]
        public DateTime TakeOff { get; set; }
        [Display(Name = "Atterrissage")]
        [DataType(DataType.DateTime)]
        public DateTime Landing { get; set; }

        public Schedule()
        {

        }

        public Schedule(String takeoff, String landing)
        {
            TakeOff = DateTime.Parse(takeoff);
            Landing = DateTime.Parse(landing);
        }

        public Schedule(DateTime takeOff, DateTime landing)
        {
            TakeOff = takeOff;
            Landing = landing;
        }

        public bool CollidesWith(Schedule sched)
        {
            return this.TakeOff < sched.Landing && sched.TakeOff < this.Landing;
        }

        public void AddDays(int d)
        {
            TakeOff = TakeOff.AddDays(d);
            Landing = Landing.AddDays(d);
        }

        public void AddMonths(int m)
        {
            TakeOff = TakeOff.AddMonths(m);
            Landing = Landing.AddMonths(m);
        }

        public static bool operator ==(Schedule sc1, Schedule sc2)
        {
            return sc1.TakeOff == sc2.TakeOff && sc1.Landing == sc2.Landing;
        }

        public static bool operator !=(Schedule sc1, Schedule sc2)
        {
            return !(sc1.TakeOff == sc2.TakeOff && sc1.Landing == sc2.Landing);
        }
    }
}
