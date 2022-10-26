using ETaraba.Domain.Models;
using ETaraba.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ETaraba.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        public RegisterCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userManager.FindByNameAsync(request.User.UserName);

            var basket = new Basket
            {
                Id = Guid.NewGuid()
            };
            var usertToCreate = new User
            {
                UserName = request.User.UserName,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                Email = request.User.Email,
                PhoneNumber = request.User.PhoneNumber,
                ProfileImgSrc = request.User.ProfileImgSrc,
                Basket = basket,
                BasketId = basket.Id

            };
            var result = await _userManager.CreateAsync(usertToCreate, request.Password);
            var addRoleToUser = await _userManager.AddToRoleAsync(usertToCreate, "User");
            return usertToCreate;
        }
    }
}
