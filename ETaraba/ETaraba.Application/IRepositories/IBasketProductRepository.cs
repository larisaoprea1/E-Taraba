using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IBasketProductRepository
    {
        Task<IEnumerable<BasketProduct>> GetBasketProductsAsync();
        Task<BasketProduct> GetBasketProductAsync(Guid basketProductId);
        Task AddBasketProductAsync(BasketProduct basketProduct);
        Task UpdateBasketProductAsync(BasketProduct basketProduct);
        void DeleteBasketProduct(BasketProduct basketProduct);
        Task SaveAsync();
    }
}
