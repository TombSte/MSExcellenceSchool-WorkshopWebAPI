namespace WorkshopWebAPI.API.Persistence.Models
{
    public class ExternalColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ColorType ColorType { get; set; }
    }

    public enum ColorType
    {
        Metallized,
        Pearl
    }
}
