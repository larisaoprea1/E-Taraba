using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETaraba.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ETarabaContext _eTarabaContext;

        public UserRepository(ETarabaContext eTarabaContext)
        {
            _eTarabaContext = eTarabaContext;
        }
        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _eTarabaContext.Users
                .Include(u => u.Basket)
                .ThenInclude(u => u.BasketProducts)
                .ThenInclude(u=>u.Product)
                .Include(u=> u.Orders)
                .ThenInclude(u => u.OrderProducts)
                .ThenInclude(u => u.Product)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _eTarabaContext.Users
                .Include(u => u.Basket)
                .ThenInclude(u => u.BasketProducts)
                .ThenInclude(u=> u.Product)
                .Include(u => u.Orders)
                .ThenInclude(u => u.OrderProducts)
                .ThenInclude(u => u.Product)
                .ToListAsync();
        }
        public void DeleteUser(User user)
        {
            _eTarabaContext.Users.Remove(user);
        }
        public async Task<bool> GetIfUserExistsAsync(Guid userId)
        {
            return await _eTarabaContext.Users.AnyAsync(u => u.Id == userId);
        }
        public async Task SaveAsync()
        {
            await _eTarabaContext.SaveChangesAsync();
        }
    }
}
