using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Responses.User;
using VeryDeli.Data.Domains;

namespace VeryDeli.Api.Commands.Handlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly UserManager<User> _userManager;

        public UserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand loginUserCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}
