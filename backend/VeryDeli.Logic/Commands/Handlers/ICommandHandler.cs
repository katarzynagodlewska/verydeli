using System.Threading.Tasks;
using VeryDeli.Logic.Models;

namespace VeryDeli.Logic.Commands.Handlers.Interfaces
{
    public interface ICommandHandler
    {
        Task<ExecuteResult> Handle(ICommand command);
    }
}
