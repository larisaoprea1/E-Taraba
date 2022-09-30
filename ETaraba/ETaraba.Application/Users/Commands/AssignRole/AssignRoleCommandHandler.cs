using ETaraba.Domain.Models;
using ETaraba.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ETaraba.Application.Users.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, bool>
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AssignRoleCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<bool> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if(role == null)
            {
                var roleAdded = await _roleManager.CreateAsync(new()
                {
                    Name = request.RoleName
                });
            }
            //var addRole = await _userManager.AddToRoleAsync(user, request.RoleName);
            //return addRole.Succeeded;
        }
    }
}
