namespace VeryDeli.Logic.Commands.Handlers.Interfaces
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        TResult Handle(TCommand command);
    }
}
