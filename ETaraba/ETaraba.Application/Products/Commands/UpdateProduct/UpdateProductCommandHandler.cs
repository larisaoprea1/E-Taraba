using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ProductPhoto = request.ProductPhoto,
                Quantity = request.Quantity,
                Price = request.Price,
            };
            await _productRepository.UpdateProductAsync(productToUpdate);
            await _productRepository.SaveAsync();
            return productToUpdate; 
        }
    }
}
