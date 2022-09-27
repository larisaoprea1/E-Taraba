using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class BasketRepository: IBasketRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public BasketRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<Basket> GetBasketAsync(Guid basketId)
        {
            return await _eTarabaContext.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(p => p.Product)
                .Where(b=>b.Id == basketId)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Basket>> GetBasketsAsync(Basket basket)
        {
            return await _eTarabaContext.Baskets
               .Include(o => o.BasketProducts)
               .ThenInclude(p => p.Product)
               .OrderBy(o => o.CreateAt)
               .ToListAsync();
        }
        public async Task CreateBasketAsync(Basket basket)
        {
            _eTarabaContext.Baskets.Add(basket);
        }
        public async Task UpdateBasketAsync(Basket basket)
        {
            _eTarabaContext.Baskets.Update(basket);
        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
