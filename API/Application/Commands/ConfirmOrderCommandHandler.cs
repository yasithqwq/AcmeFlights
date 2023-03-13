using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            Order orderToConfirm = await _orderRepository.GetAsync(request.OrderId);
            if (orderToConfirm != null)
            {
                var confirmedOrder = await _orderRepository.Confirm(orderToConfirm);
                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                confirmedOrder.OutputMessage = "Successfully Confirmed the order";
                return confirmedOrder;
            }
            else 
            {
                return new Order() { OutputMessage = "Could not found Order to confirm" };
            }
        }
    }
}
