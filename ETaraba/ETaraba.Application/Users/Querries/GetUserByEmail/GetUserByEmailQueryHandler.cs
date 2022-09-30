using ETaraba.Application.Users.Querries.GetUserByUsername;
using ETaraba.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETaraba.Application.Users.Querries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly UserManager<User> _userManager;
        public GetUserByEmailQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(request.Email);
        }
    }
}
