using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Api.Models;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Api.Responses.Food;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Queries.Handlers
{
    public class SearchFoodsQueryHandler : ISearchFoodsQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public SearchFoodsQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<SearchResponse> Handle(SearchFoodQuery searchFoodQuery)
        {
            //TODO add more complicated query to find by food type and restauraunt etc
            return new SearchResponse()
            {
                FoodModels = await _foodRepository.GetAll()
                    .AsNoTracking()
                    .Where(f => f.Name.StartsWith(searchFoodQuery.SearchFoodText))
                    .Skip(searchFoodQuery.Skip)
                    .Take(searchFoodQuery.Take == default ? 10 : searchFoodQuery.Take)
                    .Select(f => new FoodModel
                    {
                        Id = f.Id,
                        Description = f.Description,
                        Title = f.Name,
                        Price = f.Price,
                        Image = f.Image.Data
                    })
                    .ToListAsync()
            };
        }
    }
}
