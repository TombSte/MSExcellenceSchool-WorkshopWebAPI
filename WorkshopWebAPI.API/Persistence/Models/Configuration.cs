namespace WorkshopWebAPI.API.Persistence.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int EngineId { get; set; }
        public int ExternalColorId { get; set; }
        public int InternalColorId { get; set; }
        public bool SmokerPackage { get; set; }
        public int HasSmokerPackage { get; set; }
        public SeatType SeatType { get; set; }
        public bool ElettricFoldableExteriorMirrors { get; set; }
        public bool AutomaticAirConditioning { get; set; }
        public bool StoragePackage { get; set; }
    }

    public enum SeatType
    {
        Standard,
        Sport
    }
}
