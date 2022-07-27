using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class ScheduleAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Flight flight = (Flight)value;
            Schedule sched = flight.Schedule;

            if (sched.TakeOff >= sched.Landing)
            {
                return false;
            }

            return base.IsValid(value);
        }
    }
}
