using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.Food;
using VeryDeli.Logic.Queries.Data.Food;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Queries.Handlers.Food
{
    class GetFoodQueryHandler : IQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public GetFoodQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Execute(IQuery query)
        {
            var getFoodQuery = query as GetFoodQuery;
            var food = await _foodRepository.GetById(getFoodQuery.Id);

            return new FoodDetailsResult
            {
                Id = food.Id,
                Title = food.Name,
                Price = food.Price,
                Description = food.Description,
                PreparingTime = food.PreparingTime,
                Image = food.Image.Data
            };
        }
    }
}
