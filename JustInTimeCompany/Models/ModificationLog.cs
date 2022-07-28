namespace JustInTimeCompany.Models
{
    public class ModificationLog
    {
        public int Id { get; set; }
        public FlightArchive Before { get; set; }

        public FlightArchive After { get; set; }

        public ModificationLog()
        {

        }

        public ModificationLog(FlightArchive before, FlightArchive after)
        {
            Before = before;
            After = after;
        }
    }
}
