using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.AddProductToBasket
{
    public class AddProductToBasketCommand : IRequest<BasketProduct>
    {
        public Guid ProductId {get; set; }  
        public Guid UserId { get; set; }
        public int Count { get; set; } 
    }
}
