using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class RemainingSeatsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Erreur");
            var _dbContext = validationContext.GetService<JITCDbContext>();
            Booking booking = (Booking) value;
            booking.Flight = _dbContext.Flights
                .Include(fl => fl.Bookings)
                .First(fl => fl.Id == booking.FlightId);

            if(booking.Flight.RemainingSeats < booking.SeatsTaken)
            {
                return new ValidationResult("Le nombre de places voulu n'est plus disponible");
            }

            return ValidationResult.Success;
        }
    }
}
