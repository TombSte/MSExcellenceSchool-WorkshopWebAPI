namespace WorkshopWebAPI.API.Persistence.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
