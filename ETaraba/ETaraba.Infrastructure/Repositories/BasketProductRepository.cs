using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class BasketProductRepository : IBasketProductRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public BasketProductRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<IEnumerable<BasketProduct>> GetBasketProductsAsync()
        {
            return await _eTarabaContext.BasketProducts
                .Include(x => x.Product)
                .ToListAsync();
        }
        public async Task<BasketProduct> GetBasketProductAsync(Guid basketProductId)
        {
            return await _eTarabaContext.BasketProducts
                .Include(p => p.Product)
                .AsNoTracking()
                .Where(p => p.Id == basketProductId)
                .FirstOrDefaultAsync();
        }
        public async Task AddBasketProductAsync(BasketProduct basketProduct)
        {
            _eTarabaContext.BasketProducts.Add(basketProduct);
        }
        public async Task UpdateBasketProductAsync(BasketProduct basketProduct)
        {
            _eTarabaContext.BasketProducts.Update(basketProduct);
        }
        public void DeleteBasketProduct(BasketProduct basketProduct)
        {
            _eTarabaContext.BasketProducts.Remove(basketProduct);

        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
