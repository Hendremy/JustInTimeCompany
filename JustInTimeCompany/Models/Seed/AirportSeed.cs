using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models.Seed
{
    public class AirportSeed
    {
        static public void Generate (ModelBuilder mb)
        {
            var liege = new
            {
                Id = 1,
                Name = "Aéroport de Liège",
                Location = "Liège",
                Latitude = 50.63583079,
                Longitude = 5.439331576
            };

            var charleroi = new
            {
                Id = 2,
                Name = "Aéroport de Charleroi Bruxelles-Sud",
                Location = "Charleroi",
                Latitude = 50.455998176,
                Longitude = 4.45166486
            };

            var bruxelles = new
            {
                Id = 3,
                Name = "Aéroport de Bruxelles-National",
                Location = "Bruxelles",
                Latitude = 50.90082973,
                Longitude = 4.483998064
            };

            var oostende = new
            {
                Id = 4,
                Name = "Aéroport d'Ostende-Bruges",
                Location = "Ostende",
                Latitude = 51.193165894,
                Longitude = 2.858163234
            };

            mb.Entity<Airport>().HasData(liege, bruxelles, oostende, charleroi);
        }
    }
}
