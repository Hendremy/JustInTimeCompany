using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class AircraftSeed
    {
        static public void Generate(ModelBuilder mb)
        {
            SeedEngines(mb);
            SeedAircraftModels(mb);
            SeedEnginesInAircraft(mb);
            SeedAircrafts(mb);
        }

        static private void SeedEngines(ModelBuilder mb)
        {
            var rollsTurbine = new
            {
                Id = 1,
                Brand = "Rolls Royce",
                Type = "Turbine",
                Model = "250-C20F"
            };

            var lycomingPiston = new
            {
                Id = 2,
                Brand = "Lycoming",
                Type = "Piston",
                Model = "IO-540"
            };

            mb.Entity<Engine>().HasData(rollsTurbine, lycomingPiston);
        }

        static private void SeedAircraftModels(ModelBuilder mb)
        {
            var eurocopter = new
            { 
                Id = 1, 
                Name = "Eurocopter AS 355 F1/F2 Ecureuil III", 
                PassengerCapacity = 5, 
                Speed = 220
            };

            var jetranger = new 
            {
                Id = 2, 
                Name = "Bell 206 JetRanger", 
                PassengerCapacity = 4, 
                Speed = 190
            };

            var raven = new 
            {
                Id = 3,
                Name = "Robinson R44 Raven II",
                PassengerCapacity = 3,
                Speed = 190
            };

            mb.Entity<AircraftModel>().HasData(eurocopter, jetranger, raven);
        }

        static private void SeedEnginesInAircraft(ModelBuilder mb)
        {
            var eurocopterEngines = new
            {
                ModelId = 1,
                EngineId = 1,
                Quantity = 2
            };

            var jetrangerEngines = new
            {
                ModelId = 2,
                EngineId = 1,
                Quantity = 1
            };

            var ravenEngines = new
            {
                ModelId = 3,
                EngineId = 2,
                Quantity = 1
            };

            mb.Entity<EngineInAircraft>().HasData(eurocopterEngines, jetrangerEngines, ravenEngines);
        }

        static private void SeedAircrafts(ModelBuilder mb)
        {
            var aircraft1 = new
            {
                Id = 1,
                ModelId = 1,
                LastRevision = DateTime.Now
            };

            var aircraft2 = new
            {
                Id = 2,
                ModelId = 2,
                LastRevision = DateTime.Now
            };

            var aircraft3 = new
            {
                Id = 3,
                ModelId = 3,
                LastRevision = DateTime.Now
            };

            mb.Entity<Aircraft>().HasData(aircraft1, aircraft2, aircraft3);
        }
    }
}
