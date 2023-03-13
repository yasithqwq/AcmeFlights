using Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.EventHandlers
{
    public class FlightRateAvailabilityChangeEventHandler : INotificationHandler<FlightRateAvailabilityChangedEvent>
    {
        public async Task Handle(FlightRateAvailabilityChangedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Send Mail : Your Order has been confirmed. Flight : {notification.Flight.Id}. Number of seats {notification.Mutation}");
        }
    }
}
