namespace VeryDeli.Logic.Queries.Handlers.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
