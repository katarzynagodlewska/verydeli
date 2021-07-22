using System;
using MediatR;

namespace VeryDeli.Modules.Users.Core.Commands
{
    public class LoginUserCommand : IRequest<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
