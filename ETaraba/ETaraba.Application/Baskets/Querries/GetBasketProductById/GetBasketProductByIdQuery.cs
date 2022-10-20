using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketProductById
{
    public class GetBasketProductByIdQuery : IRequest<BasketProduct>
    {
        public Guid Id { get; set; }
    }
}
