using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
