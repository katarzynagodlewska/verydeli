using System;

namespace VeryDeli.Logic.Exceptions
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }
    }
}
