using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopWebAPI.API.Commands;
using WorkshopWebAPI.API.DTO;
using WorkshopWebAPI.API.Persistence;
using WorkshopWebAPI.API.Persistence.Models;
using WorkshopWebAPI.API.Services.Interfaces;

namespace WorkshopWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;
        private readonly IMediator mediator;
        public CarController(ICarService carService, IMediator mediator)
        {
            this.carService = carService;
            this.mediator = mediator;
        }

        [HttpGet("getcustomers")]
        public IActionResult GetCustomers()
        {
            var customers = carService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("getcustomer")]
        public async Task<IActionResult> GetCustomer([FromQuery]string email)
        {
            var customer = await mediator.Send(
                new GetUserCommand()
                {
                    Email = email
                }
                );
            return Ok(customer);
        }

        [HttpPost("addcustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerInputDTO customer)
        {
            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception("Email is empty");
            }

            //to do something... 

            return Ok(customer);
        }
    }
}
