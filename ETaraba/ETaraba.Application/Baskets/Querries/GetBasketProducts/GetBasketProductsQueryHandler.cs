using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketProducts
{
    public class GetBasketProductsQueryHandler : IRequestHandler<GetBasketProductsQuery, IEnumerable<BasketProduct>>
    {
        private readonly IBasketProductRepository _basketProductRepository;
        public GetBasketProductsQueryHandler(IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
        }
        public async Task<IEnumerable<BasketProduct>> Handle(GetBasketProductsQuery request, CancellationToken cancellationToken)
        {
            return await _basketProductRepository.GetBasketProductsAsync();
        }
    }
}
