﻿using ETaraba.Domain.Models;
using ETaraba.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETaraba.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, object>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<User> userManager, RoleManager<UserRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, request.Password))
            {
                var claimsForToken = new List<Claim>
                {
                    new Claim("Id", userExists.Id.ToString()),
                    new Claim("UserName", userExists.UserName),
                    new Claim("Email", userExists.Email),
                    new Claim("ProfileImage", userExists.ProfileImgSrc),
                    new Claim("IsLoggedIn", true.ToString(), ClaimValueTypes.Boolean),
                    new Claim(ClaimTypes.NameIdentifier,userExists.UserName)
                };
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Token"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["Authentication:Issuer"],
                    audience: _configuration["Authentication:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    claims: claimsForToken,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                 );
                return new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };

            }
            return "401";

        }
    }
}
