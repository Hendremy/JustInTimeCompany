using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Models.Seed
{
    public class FlightSeed
    {
        static public void Generate(ModelBuilder mb)
        {
            SeedPaths(mb);
            SeedSchedules(mb);
            SeedFlights(mb);
        }

        static private void SeedPaths(ModelBuilder mb)
        {
            var liegeostend = new { Id = 1, FromId = 1, ToId = 4 };
            var ostendliege = new { Id = 2, FromId = 4, ToId = 1 };
            var brusselsliege = new { Id = 3, FromId = 3, ToId = 1 };

            mb.Entity<Path>().HasData(liegeostend, ostendliege, brusselsliege);
        }

        static private void SeedSchedules(ModelBuilder mb)
        {
            var fut1 = new { 
                Id = 1,
                TakeOff = new DateTime(22, 10, 5, 15, 30, 0) ,
                Landing = new DateTime(22, 10, 5, 18, 0, 0)
            };

            var fut2 = new
            {
                Id = 2,
                TakeOff = new DateTime(22, 9, 15, 12, 30, 0),
                Landing = new DateTime(22, 9, 15, 14, 0, 0)
            };

            var fut3 = new
            {
                Id = 3,
                TakeOff = new DateTime(22, 9, 20, 14, 30, 0),
                Landing = new DateTime(22, 9, 20, 16, 0, 0)
            };

            var pass1 = new
            {
                Id = 4,
                TakeOff = new DateTime(22, 7, 15, 9, 30, 0),
                Landing = new DateTime(22, 7, 15, 11, 0, 0)
            };

            var pass2 = new
            {
                Id = 5,
                TakeOff = new DateTime(22, 7, 18, 20, 30, 0),
                Landing = new DateTime(22, 7, 18, 22, 0, 0)
            };

            mb.Entity<Schedule>().HasData(fut1, fut2, fut3, pass1, pass2);
        }

        static private void SeedFlights(ModelBuilder mb)
        {
            var fut1 = new
            {
                Id = 1,
                ScheduleId = 1,
                AircraftId = 1,
                PathId = 1,
                PilotId = 1
            };

            var fut2 = new
            {
                Id = 2,
                ScheduleId = 2,
                AircraftId = 1,
                PathId = 1,
                PilotId = 3
            };

            var fut3 = new
            {
                Id = 3,
                ScheduleId = 3,
                AircraftId = 2,
                PathId = 2,
                PilotId = 3
            };

            var pass1 = new
            {
                Id = 4,
                ScheduleId = 4,
                AircraftId = 3,
                PathId = 3,
                PilotId = 2
            };

            var pass2 = new
            {
                Id = 5,
                ScheduleId = 5,
                AircraftId = 3,
                PathId = 3,
                PilotId = 2
            };

            mb.Entity<Flight>().HasData(fut1, fut2, fut3, pass1, pass2);
        }
    }
}
