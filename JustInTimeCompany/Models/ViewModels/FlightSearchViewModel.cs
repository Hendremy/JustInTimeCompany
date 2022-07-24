namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightSearchViewModel
    {
        public FlightPath Path { get; set; }
        public IEnumerable<Airport> Airports { get; set; }

        public FlightSearchViewModel (IEnumerable<Airport> airports, FlightPath path)
        {
            Airports = airports;
            Path = path;
        }
    }
}
