namespace JustInTimeCompany.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public string Brand { get; set; }

        public ICollection<EngineInAircraft> EngineInAircraft { get; init; }
    }
}
