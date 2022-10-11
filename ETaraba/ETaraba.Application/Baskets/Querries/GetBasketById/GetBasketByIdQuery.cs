using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketById
{
    public class GetBasketByIdQuery :IRequest<Basket>
    {
      public Guid Id { get; set; }
    }
}
