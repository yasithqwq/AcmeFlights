using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.FlightRateIdGuid).NotEmpty().NotNull();
            RuleFor(c => c.NumberOfSeats).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
