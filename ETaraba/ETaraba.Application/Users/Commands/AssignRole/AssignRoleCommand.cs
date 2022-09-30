using MediatR;

namespace ETaraba.Application.Users.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
