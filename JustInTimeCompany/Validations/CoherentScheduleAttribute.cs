using JustInTimeCompany.Models;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class CoherentScheduleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            Schedule sched = (Schedule) value;

            if (sched.TakeOff >= sched.Landing)
            {
                return new ValidationResult("L'heure de départ doit être avant l'heure d'arrivée");
            }

            return ValidationResult.Success;
        }
    }
}
