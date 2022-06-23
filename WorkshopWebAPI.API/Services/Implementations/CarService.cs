using WorkshopWebAPI.API.Persistence;
using WorkshopWebAPI.API.Persistence.Models;
using WorkshopWebAPI.API.Services.Interfaces;

namespace WorkshopWebAPI.API.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly AudiDbContext context;
        public CarService(AudiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.context.Customers.ToList();
        }
    }
}
