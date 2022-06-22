using Microsoft.AspNetCore.Mvc;
using WorkshopWebAPI.API.Persistence;

namespace WorkshopWebAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly AudiDbContext context;
        public CarController(AudiDbContext context)
        {
            this.context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(this.context.Customers.ToList());
        }


    }
}
