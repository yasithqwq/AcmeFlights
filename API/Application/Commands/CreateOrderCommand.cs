using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string Name { get; private set; }
        public int NumberOfSeats { get; private set; }
        public Guid FlightRateIdGuid { get; private set; }

        public CreateOrderCommand(string name, int numberOfSeats, Guid flightRateIdGuid)
        {
            Name = name;
            NumberOfSeats = numberOfSeats;
            FlightRateIdGuid= flightRateIdGuid;
        }
    }
}
