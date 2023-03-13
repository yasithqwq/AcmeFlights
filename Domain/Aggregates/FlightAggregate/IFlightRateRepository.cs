using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRateRepository : IRepository<FlightRate>
    {
        Task<FlightRate> GetAsync(Guid flightId);
    }
}
