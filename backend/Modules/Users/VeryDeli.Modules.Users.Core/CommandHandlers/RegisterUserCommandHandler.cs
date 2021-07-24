using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeryDeli.Modules.Users.Core.Commands;
using VeryDeli.Modules.Users.Core.Data.Domains;
using VeryDeli.Modules.Users.Core.Services;

namespace VeryDeli.Modules.Users.Core.CommandHandlers
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.Login, false);

            if (user != null)
                throw new Exception($"Cannot register new user. User with login {request.Login} is exist in system");

            var newUser = new User
            {
                Email = request.Login,
                UserName = request.Login
            };

            var createdUser = await _userService.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
                throw new Exception(createdUser.Errors.Select(e => e.Description).ToString());

            return true;
        }
    }
}
