using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var createdOrder = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(createdOrder));
        }

        [HttpPost]
        [Route("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderCommand command)
        {
            var createdOrder = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(createdOrder));
        }
    }
}
