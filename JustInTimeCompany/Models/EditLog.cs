namespace JustInTimeCompany.Models
{
    public class EditLog
    {
        public int BeforeId { get; set; }
        public FlightArchive Before { get; set; }

        public int AfterId { get; set; }
        public FlightArchive After { get; set; }

        public int FlightId { get; set; }
        public Flight? Flight { get; set; }

        public DateTime TimeStamp { get; set; }

        public EditLog()
        {

        }

        public EditLog(int flightId, FlightArchive before, FlightArchive after)
        {
            FlightId = flightId;
            Before = before;
            After = after;
            TimeStamp = DateTime.Now;
        }
    }
}
