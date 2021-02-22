using System;
using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Services;

namespace VeryDeli.Logic.Commands.Handlers
{
    class UserCommandHandler : ICommandHandler
    {
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService, IOrderRepository orderRepository)
        {
            _userService = userService;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var loginCommand = command as LoginUserCommand;
            var user = await _userService.GetUser(loginCommand.Login);

            var userHasValidPassword = await _userService.CheckPasswordAsync(user, loginCommand.Password);

            if (!userHasValidPassword)
                throw new Exception("Password does not match login.");

            return _userService.GenerateAuthResultForUserAsync(user);
        }
    }
}
