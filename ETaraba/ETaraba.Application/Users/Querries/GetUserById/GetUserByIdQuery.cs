using ETaraba.Domain.Models;
using MediatR;

namespace ETaraba.Application.Users.Querries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
