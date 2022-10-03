using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.AddProductToBasket
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, BasketProduct>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBasketProductRepository _basketProductRepository;
        public AddProductToBasketCommandHandler(IProductRepository productRepository,IUserRepository userRepository, IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
            _productRepository = productRepository; 
            _userRepository = userRepository;
        }

        public async Task<BasketProduct> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.ProductId);
            var user = await _userRepository.GetUserAsync(request.UserId);
            var item = new BasketProduct
            {
                BasketId = user.BasketId,
                ProductId = request.ProductId,
                Quantity = request.Count,
                Price = product.Price * request.Count
            };
            await _basketProductRepository.AddBasketProductAsync(item);
            await _basketProductRepository.SaveAsync();
            return item;
        }
    }
}
