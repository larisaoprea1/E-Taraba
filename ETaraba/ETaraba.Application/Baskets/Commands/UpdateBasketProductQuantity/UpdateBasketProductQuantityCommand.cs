using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.UpdateBasketProductQuantity
{
    public class UpdateBasketProductQuantityCommand : IRequest<BasketProduct>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
