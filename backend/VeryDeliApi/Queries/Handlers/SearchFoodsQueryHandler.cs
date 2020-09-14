using System.Threading.Tasks;
using VeryDeli.Api.Queries.Handlers.Interfaces;

namespace VeryDeli.Api.Queries.Handlers
{
    public class SearchFoodsQueryHandler : ISearchFoodsQueryHandler
    {
        public SearchFoodsQueryHandler(IFoodRepository)
        {
            
        }

        public async Task Handle(SearchFoodQuery searchFoodQuery)
        {

        }
    }
}
