using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Commands.Data.Food;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.Food;

namespace VeryDeli.Logic.Commands.Handlers.Food
{
    class UpdateFoodCommandHandler : ICommandHandler
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IFoodFoodTypeRepository _foodFoodTypeRepository;

        public UpdateFoodCommandHandler(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IFoodFoodTypeRepository foodFoodTypeRepository)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _foodFoodTypeRepository = foodFoodTypeRepository;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var updateFoodCommand = command as UpdateFoodCommand;

            var food = await _foodRepository.GetById(updateFoodCommand.Id);

            food.Name = updateFoodCommand.FoodModel.Title;
            food.PreparingTime = updateFoodCommand.FoodModel.PreparingTime;
            food.Price = updateFoodCommand.FoodModel.Price;
            food.Image.Data = updateFoodCommand.FoodModel.Image.ToArray();
            food.Description = updateFoodCommand.FoodModel.Description;

            var foodTypesRelatesToCommand = _foodTypeRepository
                .GetAll()
                .ToList()
                .Where(ft => updateFoodCommand.FoodModel.FoodTypes.Contains(ft.Id))
                .ToList();

            await DeleteFoodTypesNotRelatedToUpdatingCommand(food.Id, foodTypesRelatesToCommand);

            food.FoodFoodTypes = foodTypesRelatesToCommand.Select(ft => new FoodFoodType
            {
                FoodTypeId = ft.Id
            }).ToList();

            await _foodRepository.Update(food);

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

        private async Task DeleteFoodTypesNotRelatedToUpdatingCommand(Guid foodId, List<FoodType> foodTypesRelatesToCommand)
        {
            var foodsTypesRelatedToFood = _foodFoodTypeRepository
                .GetAll()
                .Where(ff => ff.FoodId == foodId)
                .ToList();

            foreach (var item in foodsTypesRelatedToFood.Where(ff => !foodTypesRelatesToCommand.Contains(ff.FoodType)))
                await _foodFoodTypeRepository.Remove(item);
        }
    }
}
