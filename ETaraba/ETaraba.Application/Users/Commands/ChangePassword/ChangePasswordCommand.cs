using MediatR;

namespace ETaraba.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
