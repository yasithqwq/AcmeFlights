using API.Application.Commands;
using API.Application.Queries;
using FluentValidation;

namespace API.Application.Validators
{
    public class SearchFlightQueryValidator : AbstractValidator<SearchFlightsQuery>
    {
        public SearchFlightQueryValidator()
        {
            RuleFor(c => c.FlightSearchQuery).NotNull();
            RuleFor(c => c.FlightSearchQuery.Destination).NotEmpty();
        }
    }
}
