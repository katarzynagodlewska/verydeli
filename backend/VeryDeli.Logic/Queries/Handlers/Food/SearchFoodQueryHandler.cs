using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.Food;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Queries.Handlers.Food
{
    public class SearchFoodQueryHandler : IQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public SearchFoodQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Execute(IQuery query)
        {
            var searchFoodQuery = query as SearchFoodQuery;
            return new SearchResult()
            {
                FoodModels = await _foodRepository.GetAll()
                    .AsNoTracking()
                    .Where(f => string.IsNullOrWhiteSpace(searchFoodQuery.SearchFoodText) || f.Name.StartsWith(searchFoodQuery.SearchFoodText))
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
