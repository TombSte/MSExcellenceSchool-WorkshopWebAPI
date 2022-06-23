using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopWebAPI.API.DTO;
using WorkshopWebAPI.API.Persistence;
using WorkshopWebAPI.API.Persistence.Models;

namespace WorkshopWebAPI.API.Commands
{
    public record GetUserCommand : IRequest<CustomerOuputDTO>
    {
        public string Email { get; set; }
    }

    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, CustomerOuputDTO>
    {
        private readonly AudiDbContext context;
        private readonly IMapper mapper;
        public GetUserCommandHandler(AudiDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CustomerOuputDTO> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(i => i.Email.Equals(request.Email));

            var result = mapper.Map<CustomerOuputDTO>(customer);

            return result;
        }
    }
}
