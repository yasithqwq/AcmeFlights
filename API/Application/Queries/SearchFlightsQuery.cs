using Domain.SearchQueries;
using Domain.SearchResults;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public class SearchFlightsQuery : IRequest<List<FlightSearchResult>>
    {
        public FlightSearchQuery FlightSearchQuery { get; set; }
    }
}
