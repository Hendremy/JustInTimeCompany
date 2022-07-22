using JustInTimeCompany.Models;
using System.ComponentModel.DataAnnotations;

namespace DungeonHero.Validations
{
    public class DelayAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            FlightReport report = (FlightReport) value;

            if (report.HasDelay && report.DelayJustification == null)
            {
                return false;
            }

            return base.IsValid(value);
        }
    }
}
