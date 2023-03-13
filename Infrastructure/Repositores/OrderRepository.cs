using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            return _context.Orders.Add(order).Entity;
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> Confirm(Order order)
        {
            order.ConfirmChange();
            _context.Orders.Update(order);
            var flightRate = await _context.FlightRates.FirstOrDefaultAsync(o => o.Id == order.FlightRateId);
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Rates.Any(r => r.Id == flightRate.Id));
            flight.MutateRateAvailability(flightRate.Id, (order.NumberOfSeats * -1));
            return order;
        }


    }
}
