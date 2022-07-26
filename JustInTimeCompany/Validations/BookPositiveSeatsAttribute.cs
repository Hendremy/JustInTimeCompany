using JustInTimeCompany.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Validations
{
    public class BookPositiveSeatsAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Booking booking = (Booking)value;

            if (booking.SeatsTaken < 1)
            {
                return false;
            }

            return base.IsValid(value);
        }
    }
}
