using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using Domain.SearchResults;

namespace API.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price));
        }
    }
}
