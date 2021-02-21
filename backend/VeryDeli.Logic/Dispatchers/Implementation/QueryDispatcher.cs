using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Logic.Exceptions;
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
            var interfaceTypeHandler = $"I{query.GetType().Name}Handler";

            var queryHandlerType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.Name == interfaceTypeHandler).FirstOrDefault();

            var queryHandlerObject = _provider.GetService(queryHandlerType);

            if (queryHandlerObject is IQueryHandler)
            {
                var queryHandler = queryHandlerObject as IQueryHandler;

                return await queryHandler.Execute(query);
            }

            throw new QueryHandlerNotFoundException($"Could not found handler for query with type {typeof(IQuery)}");
        }
    }
}
