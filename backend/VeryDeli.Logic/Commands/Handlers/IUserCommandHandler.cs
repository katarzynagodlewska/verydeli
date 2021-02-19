using System.Threading.Tasks;
using VeryDeli.Api.Responses.User;

namespace VeryDeli.Logic.Commands.Handlers.Interfaces
{
    public interface IUserCommandHandler : ICommandHandler
    {
        Task<LoginResponse> Handle(LoginUserCommand loginUserCommand);
        Task<RegisterResponse> Handle(RegisterUserCommand registerUserCommand);
    }
}
