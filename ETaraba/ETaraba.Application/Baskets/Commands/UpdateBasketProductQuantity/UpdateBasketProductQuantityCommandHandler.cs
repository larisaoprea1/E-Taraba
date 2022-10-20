using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.UpdateBasketProductQuantity
{
    public class UpdateBasketProductQuantityCommandHandler : IRequestHandler<UpdateBasketProductQuantityCommand, BasketProduct>
    {
        private readonly IBasketProductRepository _basketProductRepository;

        public UpdateBasketProductQuantityCommandHandler(IBasketProductRepository basketProductRepository)
        {
            _basketProductRepository = basketProductRepository;
        }

        public async Task<BasketProduct> Handle(UpdateBasketProductQuantityCommand request, CancellationToken cancellationToken)
        {
            var basketProduct = await _basketProductRepository.GetBasketProductAsync(request.Id);
            basketProduct.Quantity = request.Quantity;
            basketProduct.Price = request.Quantity * basketProduct.Product.Price;

            await _basketProductRepository.SaveAsync();

            return basketProduct;
        }
    }
}
