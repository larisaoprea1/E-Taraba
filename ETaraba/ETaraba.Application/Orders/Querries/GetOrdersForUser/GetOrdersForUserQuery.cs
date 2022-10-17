using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Orders.Querries.GetOrdersForUser
{
    public class GetOrdersForUserQuery:IRequest<IEnumerable<Order>>
    {
        public Guid Id { get; set; }
    }
}
