using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models.ViewModels
{
    public class FlightSearch
    {
        [Display(Name = "Date du vol")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public FlightPath Path { get; set; }
        public IEnumerable<Airport> Airports { get; set; }

        public FlightSearch()
        {

        }

        public FlightSearch (IEnumerable<Airport> airports, FlightPath path)
        {
            Airports = airports;
            Path = path;
            Date = DateTime.Now;
        }
    }
}
