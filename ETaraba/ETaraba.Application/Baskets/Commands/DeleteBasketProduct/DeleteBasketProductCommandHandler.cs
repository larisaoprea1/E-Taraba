using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Baskets.Commands.DeleteBasketProduct
{
    public class DeleteBasketProductCommandHandler : IRequestHandler<DeleteBasketProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketProductRepository _basketProductRepository;
        public DeleteBasketProductCommandHandler(IProductRepository productRepository, IBasketProductRepository basketProductRepository)
        {
            _productRepository = productRepository;
            _basketProductRepository = basketProductRepository;
        }

        public async Task<Unit> Handle(DeleteBasketProductCommand request, CancellationToken cancellationToken)
        {
            var basketProductToDelete = await _basketProductRepository.GetBasketProductAsync(request.Id);
            _basketProductRepository.DeleteBasketProduct(basketProductToDelete);
            await _productRepository.SaveAsync();
            return Unit.Value;

        }
    }
}
