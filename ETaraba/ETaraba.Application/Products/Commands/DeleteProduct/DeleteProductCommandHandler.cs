using ETaraba.Application.IRepositories;
using MediatR;

namespace ETaraba.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetProductAsync(request.Id);
            _productRepository.DeleteProduct(entity);
            await _productRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
