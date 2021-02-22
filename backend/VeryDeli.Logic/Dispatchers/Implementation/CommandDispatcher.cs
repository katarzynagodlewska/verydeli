using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Data;
using VeryDeli.Logic.Commands;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;

namespace VeryDeli.Logic.Dispatchers.Implementation
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<ExecuteResult> Execute(ICommand command)
        {
            var typeHandlerName = $"{command.GetType().Name}Handler";

            var commandHandlerType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.Name == typeHandlerName).FirstOrDefault();

            var commandHandlerObject = ActivatorUtilities.GetServiceOrCreateInstance(_provider, commandHandlerType);

            if (commandHandlerObject is ICommandHandler)
            {
                var commandHandler = commandHandlerObject as ICommandHandler;

                return await commandHandler.Handle(command);
            }

            throw new LogicException($"Could not found handler for command: {nameof(command)}");
        }
    }
}
