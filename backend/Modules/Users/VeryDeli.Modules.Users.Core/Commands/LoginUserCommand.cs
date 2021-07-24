using System;
using MediatR;
using VeryDeli.Modules.Users.Core.Responses;

namespace VeryDeli.Modules.Users.Core.Commands
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
