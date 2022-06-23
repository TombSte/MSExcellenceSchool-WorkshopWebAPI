namespace WorkshopWebAPI.API.DTO
{
    public class CustomerOuputDTO
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthdate { get; set; }
        public bool Enabled { get; set; }
    }

    public class CustomerInputDTO
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
