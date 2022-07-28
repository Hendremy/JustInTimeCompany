namespace JustInTimeCompany.Models.ViewModels
{
    public class StatsViewModel
    {
        public IEnumerable<Flight> DelayedFlights { get; set; }
        public IEnumerable<Aircraft> Aircrafts { get; set; }

        public StatsViewModel(IEnumerable<Flight> delflight, IEnumerable<Aircraft> aircrafts)
        {
            DelayedFlights = delflight;
            Aircrafts = aircrafts;
        }
    }
}
