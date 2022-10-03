using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketsProducts
{
    public class GetBasketsProductsQuery:IRequest<IEnumerable<BasketProduct>>
    {
    }
}
