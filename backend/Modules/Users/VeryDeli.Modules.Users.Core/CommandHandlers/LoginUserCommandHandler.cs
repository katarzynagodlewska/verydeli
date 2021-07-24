using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeryDeli.Modules.Users.Core.Commands;
using VeryDeli.Modules.Users.Core.Models.Responses;
using VeryDeli.Modules.Users.Core.Services;

namespace VeryDeli.Modules.Users.Core.CommandHandlers
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.Login);

            var userHasValidPassword = await _userService.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword)
                throw new Exception("Password does not match login.");

            return _userService.GenerateAuthResultForUserAsync(user);
        }
    }
}
