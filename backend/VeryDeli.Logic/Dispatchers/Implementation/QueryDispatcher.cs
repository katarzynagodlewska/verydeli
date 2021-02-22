using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Data;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Queries;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Dispatchers.Implementation
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<ExecuteResult> Execute(IQuery query)
        {
            var typeHandlerName = $"{query.GetType().Name}Handler";

            var queryHandlerType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.Name == typeHandlerName).FirstOrDefault();

            var queryHandlerObject = ActivatorUtilities.GetServiceOrCreateInstance(_provider, queryHandlerType);

            if (queryHandlerObject is IQueryHandler)
            {
                var queryHandler = queryHandlerObject as IQueryHandler;

                return await queryHandler.Execute(query);
            }

            throw new LogicException($"Could not found handler for query: {nameof(query)}");
        }
    }
}
