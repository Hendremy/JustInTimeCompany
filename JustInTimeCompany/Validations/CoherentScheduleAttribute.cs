using JustInTimeCompany.Models;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class CoherentScheduleAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Flight flight = (Flight)value;
            Schedule sched = flight.Schedule;

            if (sched.TakeOff >= sched.Landing)
            {
                return false;
            }

            return true;
        }
    }
}
