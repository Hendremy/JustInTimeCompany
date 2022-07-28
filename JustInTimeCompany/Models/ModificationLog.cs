namespace JustInTimeCompany.Models
{
    public class ModificationLog
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public int BeforeId { get; set; }
        public FlightArchive Before { get; set; }

        public int AfterId { get; set; }
        public FlightArchive After { get; set; }

        public ModificationLog()
        {

        }

        public ModificationLog(FlightArchive before, FlightArchive after)
        {
            FlightId = before.Id;
            Before = before;
            After = after;
        }
    }
}
