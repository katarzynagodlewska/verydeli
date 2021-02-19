using System;
using System.Linq;
using System.Web.Http.Dependencies;
using VeryDeli.Logic.Queries;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Dispatchers.Implementation
{
    public class QueryDispatcher<TQuery, TResult> : IQueryDispatcher<TQuery, TResult> where TQuery : IQuery
    {
        private readonly IDependencyResolver _resolver;

        public QueryDispatcher(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TResult Execute(IQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            var repositoryTypesList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "VeryDeli.Data.Repositories.Implementation").ToList();
            
            var queryHandler 

            var handler = _resolver.GetService<IQueryHandler>()
            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }
            return handler.Execute(query);
        }
    }
}
