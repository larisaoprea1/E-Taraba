using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public OrderRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _eTarabaContext.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(p=> p.Product)
                .OrderBy(o => o.CreateAt)
                .ToListAsync();
        }
        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _eTarabaContext.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(p=> p.Product)
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();
        }
        public async Task CreateOrderAsync(Order order)
        {
            _eTarabaContext.Orders.Add(order);
        }
        public async Task UpdateOrderAsync(Order order)
        {
            _eTarabaContext.Orders.Update(order);
        }
        public void DeleteOrder(Order order)
        {
            _eTarabaContext.Orders.Remove(order);
        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
