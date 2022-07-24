namespace JustInTimeCompany.Models.ViewModels
{
    public class BookingSearchFormViewModel
    {
        public FlightPath Path { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
    }
}
