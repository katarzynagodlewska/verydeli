using VeryDeli.Logic.Commands;

namespace VeryDeli.Logic.Dispatchers
{
    public interface ICommandDispatcher
    {
        void Execute(ICommand command);
    }
}
