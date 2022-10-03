using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketsProducts
{
    public class GetBasketsProductsQueryHandler : IRequestHandler<GetBasketsProductsQuery, IEnumerable<BasketProduct>>
    {
        private readonly IBasketProductRepository _basketProductRepository;
        public GetBasketsProductsQueryHandler(IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
        }
        public async Task<IEnumerable<BasketProduct>> Handle(GetBasketsProductsQuery request, CancellationToken cancellationToken)
        {
            return await _basketProductRepository.GetBasketProductsAsync();
        }
    }
}
