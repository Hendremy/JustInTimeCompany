using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class BookPositiveSeatsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            Booking booking = (Booking)value;

            if (booking.SeatsTaken < 1)
            {
                return new ValidationResult("Le nombre de places réservées doit être positif");
            }

            return  ValidationResult.Success;
        }
    }
}
