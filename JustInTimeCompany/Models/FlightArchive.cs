namespace JustInTimeCompany.Models
{
    public class FlightArchive
    {
        public int Id { get; set; }

        //public int FlightId { get; set; }
        //public Flight? Flight { get; set; }

        public int PilotId { get; set; }
        public Pilot? Pilot { get; set; }

        public int PathId { get; set; }
        public FlightPath? Path { get; set; }
        public Schedule Schedule { get; set; }

        public int AircraftId { get; set; }
        public Aircraft? Aircraft { get; set; }

        public int? BeforeLogId { get; set; }
        public ModificationLog? BeforeLog { get; set; }

        public int AfterLogId { get; set; }
        public ModificationLog? AfterLog { get; set; }


        public FlightArchive()
        {

        }

        public FlightArchive(Flight flight)
        {
            //FlightId = flight.Id;
            PilotId = flight.PilotId;
            PathId = flight.Path.Id;
            Schedule = flight.Schedule;
            AircraftId = flight.AircraftId;
        }
    }
}
