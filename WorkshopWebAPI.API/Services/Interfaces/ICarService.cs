using WorkshopWebAPI.API.Persistence.Models;

namespace WorkshopWebAPI.API.Services.Interfaces
{
    public interface ICarService
    {
        public IEnumerable<Customer> GetCustomers();
    }
}
