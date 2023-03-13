using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using Infrastructure.Repositores;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightRateRepository _flightRateRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IFlightRepository flightRepository, IFlightRateRepository flightRateRepository)
        {
            _orderRepository = orderRepository;
            _flightRepository = flightRepository;
            _flightRateRepository = flightRateRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var flightRate = await _flightRateRepository.GetAsync(request.FlightRateIdGuid);

            if (flightRate != null)
            {
                Price price = new Price(request.NumberOfSeats * flightRate.Price.Value, flightRate.Price.Currency);

                var order = _orderRepository.Add(new Order(request.Name, price, request.NumberOfSeats, flightRate.Id, false));

                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                order.OutputMessage = "Successfully Inserted";
                return order; 
            }
            else
            {
                return new Order() { OutputMessage = "Could not found flight rate with given key"};
            }
        }
    }
}
