using System.Threading.Tasks;
using VeryDeli.Api.Responses.User;

namespace VeryDeli.Api.Commands.Handlers.Interfaces
{
    public interface IUserCommandHandler : ICommandHandler
    {
        Task<LoginResponse> Handle(LoginUserCommand loginUserCommand);
        Task<RegisterResponse> Handle(RegisterUserCommand registerUserCommand);
    }
}
