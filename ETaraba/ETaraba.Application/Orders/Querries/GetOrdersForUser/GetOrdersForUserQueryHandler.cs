using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Querries.GetOrdersForUser
{
    public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersForUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersForUser(request.Id);
        }
    }
}
