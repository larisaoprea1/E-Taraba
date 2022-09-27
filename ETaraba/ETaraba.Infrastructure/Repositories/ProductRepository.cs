using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public ProductRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _eTarabaContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _eTarabaContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
        }
        public async Task CreateProductAsync(Product product)
        {
            _eTarabaContext.Products.Add(product);
        }
        public async Task UpdateProductAsync(Product product)
        {
            _eTarabaContext.Products.Update(product);
        }
        public void DeleteProduct(Product product)
        {
            _eTarabaContext.Products.Remove(product);
        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
