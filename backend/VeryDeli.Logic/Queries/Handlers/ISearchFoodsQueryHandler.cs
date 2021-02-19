using System.Threading.Tasks;
using VeryDeli.Api.Responses.Food;

namespace VeryDeli.Logic.Queries.Handlers.Interfaces
{
    public interface ISearchFoodsQueryHandler : IQueryHandler
    {
        Task<SearchResponse> Handle(SearchFoodQuery searchFoodQuery);
    }
}
