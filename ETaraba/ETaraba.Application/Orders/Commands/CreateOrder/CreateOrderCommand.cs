using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
        public Guid UserId { get; set; }
    }
}
