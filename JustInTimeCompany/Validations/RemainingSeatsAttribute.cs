using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class RemainingSeatsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Erreur - Veuillez réessayer ultérieurement");
            var _dbContext = validationContext.GetService<JITCDbContext>();
            Booking booking = (Booking) value;
            booking.Flight = _dbContext.Flights
                .Include(fl => fl.Bookings)
                .Include(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .First(fl => fl.Id == booking.FlightId);

            if(booking.Flight.GetRemainingSeats() < booking.SeatsTaken)
            {
                return new ValidationResult("Le nombre de places voulu n'est plus disponible");
            }

            return ValidationResult.Success;
        }
    }
}
