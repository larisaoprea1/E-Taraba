using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetOrderProductsAsync();
        Task<OrderProduct> GetOrderProductAsync(Guid orderProductId);
        Task AddOrderProductAsync(OrderProduct orderProduct);
        Task UpdateOrderProductAsync(OrderProduct orderProduct);
        void DeleteOrderProduct(OrderProduct orderProduct);
        Task SaveAsync();
    }
}
