namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightFormViewModel
    {
        public Flight Flight { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
        public IEnumerable<Aircraft> Aircrafts { get; set; }

        public FlightFormViewModel(Flight flight, IEnumerable<Airport> airports, IEnumerable<Aircraft> aircrafts)
        {
            Flight = flight;
            Airports = airports;
            Aircrafts = aircrafts;
        }


    }
}
