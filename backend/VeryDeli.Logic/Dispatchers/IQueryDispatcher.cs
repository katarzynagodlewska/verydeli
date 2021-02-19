using VeryDeli.Logic.Queries;

namespace VeryDeli.Logic.Dispatchers
{
    public interface IQueryDispatcher<TQuery, TResult>
    {
        TResult Execute(IQuery query);
    }
}
