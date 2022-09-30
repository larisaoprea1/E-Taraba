﻿using MediatR;

namespace ETaraba.Application.Users.Commands.Login
{
    public class LoginCommand : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
