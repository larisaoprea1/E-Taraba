using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Users.Querries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}
