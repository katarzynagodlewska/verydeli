using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Api.Responses.Home;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Queries.Handlers
{
    public class FoodQueryHandler : IFoodQueryHandler
    {
        private readonly IFoodRepository _foodRepository;

        public FoodQueryHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<HomeFoodsResponse> Handle(HomeFoodsQuery homeFoodsQuery)
        {
            //TODO GET by localization or add more
            return new HomeFoodsResponse
            {
                HomeFoodModels =
                    await _foodRepository
                        .GetAll()
                        .Include(f=>f.Image)
                        .Include(f=>f.FoodFoodTypes)
                        .Where(f =>
                            f.FoodFoodTypes.Select(fft => fft.FoodTypeId).Contains(homeFoodsQuery.FoodType))
                        .Take(12)
                        .Select(f => new HomeFoodModel()
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
