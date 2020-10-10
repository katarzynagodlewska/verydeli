using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Responses.Food;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Commands.Handlers
{
    public class FoodCommandHandler : IFoodCommandHandler
    {
        private readonly IFoodRepository _foodRepository;

        public FoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<FoodDetailsResponse> Handle(Restaurant restaurantUser, FoodCommand foodCommand)
        {
            var food = new Food
            {
                Name = null,
                Description = null,
                Price = 0,
                Quantity = 0,
                PreparingTime = 0,
                Restaurant = restaurantUser, //context
                Image = null,
                FoodFoodTypes = null,
            };

            food = await _foodRepository.Add(food);

            return new FoodDetailsResponse
            {
                Id = default,
                Title = null,
                Price = 0,
                Description = null,
                PreparingTime = 0,
                Image = new byte[]
                {
                }
            };
        }

        public async Task<FoodDetailsResponse> Handle(Guid id, FoodCommand foodCommand)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteFoodResponse> Handle(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
