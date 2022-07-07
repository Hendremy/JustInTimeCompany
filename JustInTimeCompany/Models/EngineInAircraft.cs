namespace JustInTimeCompany.Models
{
    public class EngineInAircraft
    {
        public int ModelId { get; set; }
        public AircraftModel Model { get; set; }

        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        public int Quantity { get; set; }
    }
}
