using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.Food;
using VeryDeli.Logic.Queries.Data.Food;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Queries.Handlers.Food
{
    class SearchRestaurantQueryHandler : IQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public SearchRestaurantQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Execute(IQuery query)
        {
            var searchRestaurantQuery = query as SearchRestaurantQuery;

            return new FoodList()
            {
                FoodListItems = await _foodRepository
                .GetAll()
                .Include(f => f.Restaurant)
                .Where(f => f.Restaurant.Id == searchRestaurantQuery.RestaurantId)
                .Select(f => new FoodListItem()
                {
                    Id = f.Id,
                    Title = f.Name,
                    Price = f.Price,
                    Description = f.Description,
                    PreparingTime = f.PreparingTime,
                })
                .ToListAsync()
            };
        }
    }
}
