using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Querries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
