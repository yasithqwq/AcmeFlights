using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.SearchQueries;
using Domain.SearchResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(
        ILogger<FlightsController> logger,
        IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IEnumerable<FlightResponse>> GetAvailableFlights(string destination)
    {
        FlightSearchQuery query = new FlightSearchQuery() { Destination = destination };
        List<FlightSearchResult> data = await _mediator.Send(new SearchFlightsQuery() { FlightSearchQuery = query });


        return _mapper.Map<IEnumerable<FlightResponse>>(data);
    }
}
