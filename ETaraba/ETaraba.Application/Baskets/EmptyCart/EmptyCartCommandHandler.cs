using ETaraba.Application.Baskets.Commands.EmptyCart;
using ETaraba.Application.IRepositories;
using MediatR;

namespace ETaraba.Application.Baskets.EmptyCart
{
    public class EmptyCartCommandHandler : IRequestHandler<EmptyCartCommand>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBasketProductRepository _basketProductRepository;

        public EmptyCartCommandHandler(IBasketRepository basketRepository, IUserRepository userRepository, IBasketProductRepository basketProductRepository)
        {
            _basketRepository = basketRepository;
            _userRepository = userRepository;
            _basketProductRepository = basketProductRepository;
        }

        public async Task<Unit> Handle(EmptyCartCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId);
            var basket = await _basketRepository.GetBasketAsync(user.BasketId);
            basket.BasketProducts.Clear();
            await _basketProductRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
