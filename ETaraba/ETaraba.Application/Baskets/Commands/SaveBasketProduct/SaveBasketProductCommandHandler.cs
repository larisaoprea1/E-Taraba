using ETaraba.Application.IRepositories;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.SaveBasketProduct
{
    public class SaveBasketProductCommandHandler : IRequestHandler<SaveBasketProductCommand>
    {       
        private readonly IBasketProductRepository _basketProductRepository;
        public SaveBasketProductCommandHandler(IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
        }

        public async Task<Unit> Handle(SaveBasketProductCommand request, CancellationToken cancellationToken)
        {
            await _basketProductRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
