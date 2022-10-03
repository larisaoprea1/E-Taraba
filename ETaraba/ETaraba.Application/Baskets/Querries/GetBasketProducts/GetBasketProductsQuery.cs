using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketProducts
{
    public class GetBasketProductsQuery:IRequest<IEnumerable<BasketProduct>>
    {
    }
}
