using JustInTimeCompany.Models;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class FutureScheduleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            Schedule sched = (Schedule)value;

            if (sched.TakeOff < DateTime.Now || sched.Landing < DateTime.Now)
            {
                return new ValidationResult("L'horaire ne peut être dans le passé");
            }

            return ValidationResult.Success;
        }
    }
}
