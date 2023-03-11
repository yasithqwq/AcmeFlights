using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateAirportCommand : IRequest<Airport>
    {
        public string Code { get; private set; }
        
        public string Name { get; private set; }

        public CreateAirportCommand(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}