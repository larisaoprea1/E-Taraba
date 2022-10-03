using MediatR;

namespace ETaraba.Application.Baskets.Commands.DeleteBasketProduct
{
    public class DeleteBasketProductCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
