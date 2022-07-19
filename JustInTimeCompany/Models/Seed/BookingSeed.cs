using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models.Seed
{
    public class BookingSeed
    {
        static public void Generate(ModelBuilder mb)
        {
            var fut1 = new { FlightId = 1, CustomerId = 1 };

            var fut2 = new { FlightId = 2, CustomerId = 1 };

            var fut3 = new { FlightId = 3, CustomerId = 2 };

            var pass1 = new { FlightId = 4, CustomerId = 1 };

            var pass2 = new { FlightId = 5, CustomerId = 3 };

            mb.Entity<Booking>().HasData(fut1, fut2, fut3, pass1, pass2);
        }
    }
}
