using System;
using System.Collections.Generic;
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
        private readonly IFoodFoodTypeRepository _foodFoodTypeRepository;

        public FoodCommandHandler(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IFoodFoodTypeRepository foodFoodTypeRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _foodFoodTypeRepository = foodFoodTypeRepository;
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
            food.Description = foodCommand.Description;

            var foodTypesRelatesToCommand = _foodTypeRepository
                .GetAll()
                .ToList()
                .Where(ft => foodCommand.FoodTypes.Contains(ft.Id.ToString()))
                .ToList();

            await DeleteFoodTypesNotRelatedToUpdatingCommand(food.Id, foodTypesRelatesToCommand);

            food.FoodFoodTypes = foodTypesRelatesToCommand.Select(ft => new FoodFoodType
            {
                FoodTypeId = ft.Id
            }).ToList();

            await _foodRepository.Update(food);

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

        private async Task DeleteFoodTypesNotRelatedToUpdatingCommand(Guid foodId, List<FoodType> foodTypesRelatesToCommand)
        {
            var foodsTypesRelatedToFood = _foodFoodTypeRepository
                .GetAll()
                .Where(ff => ff.FoodId == foodId)
                .ToList();

            foreach (var item in foodsTypesRelatedToFood.Where(ff => !foodTypesRelatesToCommand.Contains(ff.FoodType)))
                await _foodFoodTypeRepository.Remove(item);
        }

        public async Task<DeleteFoodResponse> Handle(Guid id)
        {
            //TODO or set isdeleted flag. It could be stored as historical data?
            await _foodRepository.RemoveById(id);

            return new DeleteFoodResponse() { ResponseMessage = "Succcessfully deleted food item" };
        }
    }
}
