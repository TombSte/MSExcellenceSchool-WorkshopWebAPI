using WorkshopWebAPI.API.Persistence;
using WorkshopWebAPI.API.Persistence.Models;
using WorkshopWebAPI.API.Services.Interfaces;

namespace WorkshopWebAPI.API.Services.Implementations
{
    public class MockedCarService : ICarService
    {
        private readonly AudiDbContext context;
        public MockedCarService(AudiDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Birthdate = DateTime.Now,
                    Email = "stefano.tomba@nttdata.com",
                    Firstname = "Stefano",
                    Id = Guid.NewGuid(),
                    Lastname = "Tomba",
                    Phone = "0234435435"
                }
            };
            return customers;
        }
    }
}
