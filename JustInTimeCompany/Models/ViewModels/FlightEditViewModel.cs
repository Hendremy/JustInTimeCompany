namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightEditViewModel
    {
        public Flight Flight { get; set; }
        public IEnumerable<Pilot> Pilots { get; set; }
        public IEnumerable<Airport> Airports { get; set; }
        public IEnumerable<Aircraft> Aircrafts { get; set; }

        public FlightEditViewModel(Flight flight, IEnumerable<Pilot> pilots, 
            IEnumerable<Airport> airports, IEnumerable<Aircraft> aircrafts)
        {
            Flight = flight;
            Pilots = pilots;
            Airports = airports;
            Aircrafts = aircrafts;
        }
    }
}
