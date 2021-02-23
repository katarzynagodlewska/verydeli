using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data;
using VeryDeli.Data.Data;
using VeryDeli.Logic.Commands;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;

namespace VeryDeli.Logic.Dispatchers.Implementation
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;
        private readonly VeryDeliDataContext _veryDeliDataContext;

        public CommandDispatcher(IServiceProvider provider, VeryDeliDataContext veryDeliDataContext)
        {
            _provider = provider;
            _veryDeliDataContext = veryDeliDataContext;
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

        public async Task<ExecuteResult> ExecuteWithTransaction(ICommand command)
        {
            var transaction = await _veryDeliDataContext.Database.BeginTransactionAsync();

            try
            {
                var typeHandlerName = $"{command.GetType().Name}Handler";

                var commandHandlerType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(t => t.GetTypes())
                    .Where(t => t.Name == typeHandlerName).FirstOrDefault();

                var commandHandlerObject = ActivatorUtilities.GetServiceOrCreateInstance(_provider, commandHandlerType);

                if (commandHandlerObject is ICommandHandler)
                {
                    var commandHandler = commandHandlerObject as ICommandHandler;

                    var result = await commandHandler.Handle(command);
                    await transaction.CommitAsync();

                    return result;
                }

                throw new LogicException($"Could not found handler for command: {nameof(command)}");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
