namespace WorkshopWebAPI.API.Persistence.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
