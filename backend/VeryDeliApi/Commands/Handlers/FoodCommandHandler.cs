using System;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Responses.Food;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Api.Commands.Handlers
{
    public class FoodCommandHandler : IFoodCommandHandler
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;

        public FoodCommandHandler(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
        }

        public async Task<FoodDetailsResponse> Handle(Restaurant restaurantUser, FoodCommand foodCommand)
        {
            var foodTypesRelatesToCommand = _foodTypeRepository
                .GetAll()
                .Where(ft => foodCommand.FoodTypes.Contains(ft.Id.ToString()))
                .ToList();

            var food = new Food
            {
                Name = foodCommand.Title,
                Description = foodCommand.Description,
                Price = foodCommand.Price,
                PreparingTime = foodCommand.PreparingTime,
                Restaurant = restaurantUser, //context
                Image = new Image
                {
                    FileName = "testName",
                    Data = foodCommand.Image,
                    Length = foodCommand.Image.Length,
                    ContentType = "image/jpeg",
                },
                FoodFoodTypes = foodTypesRelatesToCommand.Select(ft => new FoodFoodType()
                {
                    FoodType = ft,
                    FoodTypeId = ft.Id
                }).ToList()
            };

            food = await _foodRepository.Add(food);

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
