using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.User;
using VeryDeli.Logic.Services;

namespace VeryDeli.Logic.Commands.Handlers.User
{
    class RegisterUserCommandHandler : ICommandHandler
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var registerCommand = command as RegisterUserCommand;

            var user = await _userService.GetUser(registerCommand.Login, false);

            if (user != null)
                throw new Exception($"Cannot register new user. User with login {registerCommand.Login} is exist in system");

            var newUser = new VeryDeli.Data.Domains.User
            {
                Email = registerCommand.Login,
                UserName = registerCommand.Login
            };

            var createdUser = await _userService.CreateAsync(newUser, registerCommand.Password);

            if (!createdUser.Succeeded)
                throw new Exception(createdUser.Errors.Select(e => e.Description).ToString());

            return new RegisterResult
            {
                Success = true
            };
        }
    }
}
