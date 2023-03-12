using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using Domain.SearchQueries;
using Domain.SearchResults;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.FirstOrDefaultAsync(o => o.Id == flightId);
        }

        public async Task<List<FlightSearchResult>> SearchAsync(FlightSearchQuery searchQuery)
        {
            List<FlightSearchResult> searchResult = await _context.Flights.Include(f=>f.Rates).Where(f=>f.Rates.Count() > 0)
                .Join(_context.Airports, fl => fl.DestinationAirportId, ap => ap.Id, (fl, ap) => new
            {
                departureAirportCode = fl.OriginAirportId.ToString(),
                arrivalAirportCode = fl.DestinationAirportId.ToString(),
                departureDatetime = fl.Departure,
                arrivalDatetime = fl.Arrival,
                destination = ap.Name,
                lowestPrice = fl.Rates.Min(r => r.Price.Value),
            }).Where(x => x.destination.Contains(searchQuery.Destination)).Select(x => new FlightSearchResult
            {
                DepartureAirportCode = x.departureAirportCode,
                ArrivalAirportCode = x.arrivalAirportCode,
                DepartureDatetime = x.departureDatetime,
                ArrivalDatetime = x.arrivalDatetime,
                Destination = x.destination,
                LowestPrice = x.lowestPrice
            }).ToListAsync();

            return searchResult;
        }
    }
}
