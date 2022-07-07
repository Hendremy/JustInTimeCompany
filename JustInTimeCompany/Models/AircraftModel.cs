namespace JustInTimeCompany.Models
{
    public class AircraftModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassengerCapacity { get; set; }
        public double Speed { get; set; }

        public ICollection<EngineInAircraft> Engines { get; init; }
    }
}
