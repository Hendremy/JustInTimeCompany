using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DungeonHero.Validations
{
    public class DelayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Erreur");
            var _dbContext = validationContext.GetService<JITCDbContext>();
            FlightReport report = (FlightReport) value;
            report.Flight = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .First(fl => fl.Id == report.FlightId);

            if(report.HasDelay && String.IsNullOrEmpty(report.DelayJustification))
            {
                return new ValidationResult("Veuillez renseigner la raison du retard de votre vol");
            }

            return ValidationResult.Success;
        }
    }
}
