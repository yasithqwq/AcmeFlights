using Domain.Aggregates.AirportAggregate;
using Domain.SearchQueries;
using Domain.SearchResults;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);

        Task<List<FlightSearchResult>> SearchAsync(FlightSearchQuery searchQuery);
    }
}