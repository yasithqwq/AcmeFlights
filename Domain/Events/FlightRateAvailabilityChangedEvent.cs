using Domain.Aggregates.FlightAggregate;
using MediatR;

namespace Domain.Events
{
    public class FlightRateAvailabilityChangedEvent : INotification
    {
        public Flight Flight { get; private set; }
        public FlightRate FlightRate { get; private set; }
        public int Mutation { get; private set; }

        public FlightRateAvailabilityChangedEvent(Flight flight, FlightRate flightRate, int mutation)
        {
            Flight = flight;
            FlightRate = flightRate;
            Mutation = mutation;
        }
    }
}