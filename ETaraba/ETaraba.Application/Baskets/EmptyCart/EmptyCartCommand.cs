using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.EmptyCart
{
    public class EmptyCartCommand: IRequest
    {
        public Guid UserId { get; set; }
    }
}
