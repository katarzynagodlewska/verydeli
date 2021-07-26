﻿using MediatR;
using VeryDeli.Modules.Users.Core.Data.Enums;

namespace VeryDeli.Modules.Users.Core.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
