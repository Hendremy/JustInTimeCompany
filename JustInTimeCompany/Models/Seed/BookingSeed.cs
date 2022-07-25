using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models.Seed
{
    public class BookingSeed
    {
        static public void Generate(ModelBuilder mb)
        {
            var fut1 = new { Id = 1, FlightId = 1, CustomerId = 1, SeatsTaken = 1 };

            var fut2 = new { Id = 2, FlightId = 2, CustomerId = 1, SeatsTaken = 1 };

            var fut3 = new { Id = 3, FlightId = 3, CustomerId = 2, SeatsTaken = 1 };

            var pass1 = new { Id = 4, FlightId = 4, CustomerId = 1, SeatsTaken = 1 };

            var pass2 = new { Id = 5, FlightId = 5, CustomerId = 3, SeatsTaken = 1 };

            mb.Entity<Booking>().HasData(fut1, fut2, fut3, pass1, pass2);
        }
    }
}
