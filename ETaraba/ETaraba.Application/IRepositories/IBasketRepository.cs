using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IBasketRepository
    {
        Task<IEnumerable<Basket>> GetBasketsAsync();
        Task<Basket> GetBasketAsync(Guid basketId);
        Task CreateBasketAsync(Basket basket);
        Task UpdateBasketAsync(Basket basket);
        Task SaveAsync();
    }
}
