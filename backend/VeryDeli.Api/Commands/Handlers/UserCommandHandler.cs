using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Responses.User;
using VeryDeli.Api.Services.Abstraction;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Commands.Handlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService, IOrderRepository orderRepository)
        {
            _userService = userService;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand loginUserCommand)
        {
            var user = await _userService.GetUser(loginUserCommand.Login);

            var userHasValidPassword = await _userService.CheckPasswordAsync(user, loginUserCommand.Password);

            if (!userHasValidPassword)
                throw new Exception("Password does not match login.");

            return _userService.GenerateAuthResultForUserAsync(user);
        }

        public async Task<RegisterResponse> Handle(RegisterUserCommand registerUserCommand)
        {
            var user = await _userService.GetUser(registerUserCommand.Login, false);

            if (user != null)
                throw new Exception(
                    $"Cannot register new user. User with login {registerUserCommand.Login} is exist in system");

            var newUser = new User
            {
                Email = registerUserCommand.Login,
                UserName = registerUserCommand.Login
            };

            var createdUser = await _userService.CreateAsync(newUser, registerUserCommand.Password);

            if (!createdUser.Succeeded)
                throw new Exception(createdUser.Errors.Select(e => e.Description).ToString());

            return new RegisterResponse
            {
                Success = true
            };
        }
    }
}
