using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketProductById
{
    public class GetBasketProductByIdQueryHandler : IRequestHandler<GetBasketProductByIdQuery, BasketProduct>
    {
        private readonly IBasketProductRepository _basketProductRepository;
        public GetBasketProductByIdQueryHandler(IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
        }

        public async Task<BasketProduct> Handle(GetBasketProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _basketProductRepository.GetBasketProductAsync(request.Id);
        }
    }
}
