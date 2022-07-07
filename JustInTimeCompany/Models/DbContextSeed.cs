using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models
{
    public class DbContextSeed
    {
        static public void Aircrafts(ModelBuilder mb)
        {
            

            

            Aircraft aircraft1 = new Aircraft()
            {
                Id = 1/*, Model = eurocopter*/, LastRevision = DateTime.Now
            };

            Aircraft aircraft2= new Aircraft()
            {
                Id = 2, /*Model = jetranger, */LastRevision = DateTime.Now
            };

            Aircraft aircraft3 = new Aircraft()
            {
                Id = 3,
                //Model = raven,
                LastRevision = DateTime.Now
            };
        }

        private void Engines(ModelBuilder mb)
        {
            var rollsTurbine = new Engine()
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

        private void AircraftModels(ModelBuilder mb)
        {
            var eurocopter = new AircraftModel()
            { 
                Id = 1, Name = "Eurocopter AS 355 F1/F2 Ecureuil III", PassengerCapacity = 5, Speed = 220,
            };

            var jetranger = new AircraftModel()
            {
                Id = 2, 
                Name = "Bell 206 JetRanger", 
                PassengerCapacity = 4, 
                Speed = 190,
                //Engines = new List<Engine>() { rollsTurbine}
            };

            var raven = new AircraftModel()
            {
                Id = 3,
                Name = "Robinson R44 Raven II",
                PassengerCapacity = 3,
                Speed = 190,
                //Engines = new List<Engine>() { lycomingPiston }
            };
        }
    }
}
