using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Api.Models;
using VeryDeli.Api.Queries.Handlers.Interfaces;
using VeryDeli.Api.Responses.Food;
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
                FoodModels =
                    await _foodRepository
                        .GetAll()
                        .Include(f => f.Image)
                        .Include(f => f.FoodFoodTypes)
                        .Where(f =>
                            f.FoodFoodTypes.Select(fft => fft.FoodTypeId).Contains(homeFoodsQuery.FoodType))
                        .Take(12)
                        .Select(f => new FoodModel()
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

        public async Task<FoodDetailsResponse> Handle(Guid id)
        {
            var food = await _foodRepository.GetById(id);

            return new FoodDetailsResponse
            {
                Id = food.Id,
                Title = food.Name,
                Price = food.Price,
                Description = food.Description,
                PreparingTime = food.PreparingTime,
                Image = food.Image.Data
            };
        }

        public async Task<List<FoodListItemResponse>> Handle(SearchRestaurantQuery searchRestaurantQuery)
        {
            return await _foodRepository
                .GetAll()
                .Include(f => f.Restaurant)
                .Where(f => f.Restaurant.Id == searchRestaurantQuery.RestaurantId)
                .Select(f => new FoodListItemResponse()
                {
                    Id = f.Id,
                    Title = f.Name,
                    Price = f.Price,
                    Description = f.Description,
                    PreparingTime = f.PreparingTime,
                })
                .ToListAsync();
        }
    }
}
