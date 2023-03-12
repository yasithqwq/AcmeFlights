using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.SearchResults;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightSearchResult, FlightResponse>()
                .ConstructUsing(x => new FlightResponse(x.DepartureAirportCode, x.ArrivalAirportCode, x.DepartureDatetime, x.ArrivalDatetime, x.LowestPrice));
        }
    }
}
