using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(Guid orderId);
        Task<IEnumerable<Order>> GetOrdersForUser(Guid userId);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        void DeleteOrder(Order order);
        Task SaveAsync();
    }
}
