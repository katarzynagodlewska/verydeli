using System.Threading.Tasks;

namespace VeryDeli.Api.Queries.Handlers.Interfaces
{
    public interface ISearchFoodsQueryHandler : IQueryHandler
    {
        Task Handle(SearchFoodQuery searchFoodQuery);
    }
}
