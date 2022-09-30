using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Users.Querries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
