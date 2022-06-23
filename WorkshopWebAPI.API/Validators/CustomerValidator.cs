using FluentValidation;
using WorkshopWebAPI.API.DTO;

namespace WorkshopWebAPI.API.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerInputDTO>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Birthdate).Custom((birthdate, context) =>
            {
                if(birthdate.Year > 2000)
                {
                    context.AddFailure("Birthdate must be > 2000");
                }
            });
        }
    }
}
