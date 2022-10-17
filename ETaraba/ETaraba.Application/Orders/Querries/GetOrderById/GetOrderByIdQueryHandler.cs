using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Querries.GetOrderById
{
    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderAsync(request.Id);
        }
    }
}
