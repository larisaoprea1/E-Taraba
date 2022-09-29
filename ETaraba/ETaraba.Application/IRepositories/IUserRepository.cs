using ETaraba.Domain.Models;

namespace ETaraba.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid userId);
        Task<IEnumerable<User>> GetUsersAsync();
        void DeleteUser(User user);
        Task<bool> GetIfUserExistsAsync(Guid userId);
        Task SaveAsync();
    }
}
