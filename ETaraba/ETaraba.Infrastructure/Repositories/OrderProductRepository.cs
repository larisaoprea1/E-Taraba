using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public OrderProductRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<IEnumerable<OrderProduct>> GetOrderProductsAsync()
        {
            return await _eTarabaContext.OrderProducts
                .Include(x => x.Product)
                .ToListAsync();
        }
        public async Task<OrderProduct> GetOrderProductAsync(Guid orderProductId)
        {
            return await _eTarabaContext.OrderProducts
                .Include(p => p.Product)
                .AsNoTracking()
                .Where(p => p.Id == orderProductId)
                .FirstOrDefaultAsync();
        }
        public async Task AddOrderProductAsync(OrderProduct orderProduct)
        {
            _eTarabaContext.OrderProducts.Add(orderProduct);
        }
        public async Task UpdateOrderProductAsync(OrderProduct orderProduct)
        {
            _eTarabaContext.OrderProducts.Update(orderProduct);
        }
        public void DeleteOrderProduct(OrderProduct orderProduct)
        {
            _eTarabaContext.OrderProducts.Remove(orderProduct);

        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
