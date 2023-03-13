using Domain.Events;
using MediatR;
using System;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.EventHandlers
{
    public class FlightRatePriceChangeEventHandler : INotificationHandler<FlightRatePriceChangedEvent>
    {
        public async Task Handle(FlightRatePriceChangedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Send Mail : Flight prices changed, Chaged RateId : {notification.FlightRate.Id}");
        }
    }
}
