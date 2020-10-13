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
                .ToList()
                .Where(ft => foodCommand.FoodTypes.Contains(ft.Id.ToString()))
                .ToList();

            var food = new Food
            {
                Name = foodCommand.Title,
                Description = foodCommand.Description,
                Price = foodCommand.Price,
                PreparingTime = foodCommand.PreparingTime,
                Restaurant = restaurantUser,
                Image = new Image
                {
                    FileName = "testName",
                    Data = foodCommand.Image.ToArray(),
                    Length = foodCommand.Image.Count(),
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
            var food = await _foodRepository.GetById(id);

            food.Name = foodCommand.Title;
            food.PreparingTime = foodCommand.PreparingTime;
            food.Price = foodCommand.Price;
            food.Image.Data = foodCommand.Image.ToArray();

            var foodTypesRelatesToCommand = _foodTypeRepository
                .GetAll()
                .ToList()
                .Where(ft => foodCommand.FoodTypes.Contains(ft.Id.ToString()))
                .ToList();

            food.FoodFoodTypes = foodTypesRelatesToCommand;

            await _foodRepository.Update(food);

            return new FoodDetailsResponse();
        }

        public async Task<DeleteFoodResponse> Handle(Guid id)
        {
            //or set flag isdeleted = true
            await _foodRepository.RemoveById(id);

            return new DeleteFoodResponse();
        }
    }
}
