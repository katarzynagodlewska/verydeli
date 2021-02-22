using System.Threading.Tasks;
using VeryDeli.Logic.Commands;
using VeryDeli.Logic.Models;

namespace VeryDeli.Logic.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<ExecuteResult> Execute(ICommand command);
    }
}
