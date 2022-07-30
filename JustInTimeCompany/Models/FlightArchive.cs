namespace JustInTimeCompany.Models
{
    public class FlightArchive
    {
        public int Id { get; set; }

        public int PilotId { get; set; }
        public Pilot? Pilot { get; set; }

        public int PathId { get; set; }
        public FlightPath? Path { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int AircraftId { get; set; }
        public Aircraft? Aircraft { get; set; }

        public int? BeforeLogId { get; set; }
        public EditLog? BeforeLog { get; set; }

        public int AfterLogId { get; set; }
        public EditLog? AfterLog { get; set; }


        public FlightArchive()
        {

        }

        public FlightArchive(Flight flight)
        {
            PilotId = flight.PilotId;
            PathId = flight.Path.Id;
            ScheduleId = flight.Schedule.Id;
            AircraftId = flight.AircraftId;
        }
    }
}
