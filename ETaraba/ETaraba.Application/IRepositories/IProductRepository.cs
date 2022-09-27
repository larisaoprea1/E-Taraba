using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        void DeleteProduct(Product product);
        Task SaveAsync();
    }
}
