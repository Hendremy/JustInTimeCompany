namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightDetailsEditViewModel
    {
        public Flight Flight { get; set; }
        public IEnumerable<Aircraft> Aircrafts { get; set; }
        public IEnumerable<Pilot> Pilots { get; set; }

        public FlightDetailsEditViewModel(Flight fl, IEnumerable<Aircraft> air, IEnumerable<Pilot> p)
        {
            Flight = fl;
            Aircrafts = air;
            Pilots = p;
        }
    }
}
