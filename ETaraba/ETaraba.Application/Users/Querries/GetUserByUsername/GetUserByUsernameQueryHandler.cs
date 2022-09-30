using ETaraba.Application.IRepositories;
using ETaraba.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETaraba.Application.Users.Querries.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly UserManager<User> _userManager;
        public GetUserByUsernameQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(request.UserName);
        }
    }
}
