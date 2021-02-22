using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Data.Food;
using VeryDeli.Logic.Models.Results.Food;
using VeryDeli.Logic.Queries.Data.Food;
using VeryDeli.Logic.Queries.Handlers.Interfaces;

namespace VeryDeli.Logic.Queries.Handlers.Food
{
    class HomeFoodQueryHandler : IQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public HomeFoodQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Execute(IQuery query)
        {
            var homeFoodQuery = query as HomeFoodQuery;

            //TODO GET by localization or add more
            return new HomeFoodsResult
            {
                FoodModels =
                    await _foodRepository
                        .GetAll()
                        .Include(f => f.Image)
                        .Include(f => f.FoodFoodTypes)
                        .Where(f =>
                            f.FoodFoodTypes.Select(fft => fft.FoodTypeId).Contains(homeFoodQuery.FoodType))
                        .Take(12)
                        .Select(f => new FoodModel()
                        {
                            Id = f.Id,
                            Description = f.Description,
                            Title = f.Name,
                            Price = f.Price,
                            Image = f.Image.Data,
                            FoodTypes = f.FoodFoodTypes.Select(fft => fft.FoodTypeId).ToList()
                        })
                        .ToListAsync()
            };
        }
    }
}
