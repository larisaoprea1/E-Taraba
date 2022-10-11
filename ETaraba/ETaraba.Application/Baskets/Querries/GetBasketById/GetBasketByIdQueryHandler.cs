using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Querries.GetBasketById
{
    public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, Basket>
    {
        private readonly IBasketRepository _basketRepository;
        public GetBasketByIdQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;   
        }
        public async Task<Basket> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _basketRepository.GetBasketAsync(request.Id);
        }
    }
}
