namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightEditViewModel
    {
        public Flight Flight { get; set; }
        public IEnumerable<Airport> Airports { get; set; }

        public FlightEditViewModel(Flight flight, IEnumerable<Airport> airports)
        {
            Flight = flight;
            Airports = airports;
        }
    }
}
