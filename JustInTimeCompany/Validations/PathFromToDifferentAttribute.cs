using JustInTimeCompany.Models;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class PathFromToDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            Flight flight = (Flight)value;

            if (flight.FromId == flight.ToId)
            {
                return new ValidationResult("L'aéroport de départ et d'arrivée doivent être différents");
            }

            return ValidationResult.Success;
        }
    }
}
