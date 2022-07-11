using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models
{
    public class AircraftModel
    {
        public int Id { get; set; }

        [Display(Name="Nom")]
        public string Name { get; set; }
        public int PassengerCapacity { get; set; }
        public int Speed { get; set; }

        public ICollection<EngineInAircraft> Engines { get; init; }
    }
}
