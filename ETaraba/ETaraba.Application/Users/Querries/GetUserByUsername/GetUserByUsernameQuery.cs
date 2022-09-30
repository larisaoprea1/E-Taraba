using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Users.Querries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string UserName { get; set; }
    }
}
