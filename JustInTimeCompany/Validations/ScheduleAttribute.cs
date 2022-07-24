using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class ScheduleAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Schedule sched = (Schedule)value;

            if (sched.TakeOff >= sched.Landing)
            {
                return false;
            }

            return base.IsValid(value);
        }
    }
}
