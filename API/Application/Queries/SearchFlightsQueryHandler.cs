using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SearchResults;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries
{
    public class SearchFlightsQueryHandler : IRequestHandler<SearchFlightsQuery, List<FlightSearchResult>>
    {

        private readonly IFlightRepository _flightRepository;

        public SearchFlightsQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightSearchResult>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
        {
            var searchResults = await _flightRepository.SearchAsync(request.FlightSearchQuery);
            return searchResults;
        }
    }
}
