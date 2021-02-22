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
    class CreateFoodCommandHandler : ICommandHandler
    {
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IFoodRepository _foodRepository;

        public CreateFoodCommandHandler(IFoodTypeRepository foodTypeRepository, IFoodRepository foodRepository)
        {
            _foodTypeRepository = foodTypeRepository;
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var createFoodCommand = command as CreateFoodCommand;

            var foodTypesRelatesToCommand = _foodTypeRepository
                           .GetAll()
                           .ToList()
                           .Where(ft => createFoodCommand.CreateFoodModel.FoodTypes.Contains(ft.Id))
                           .ToList();

            var food = new VeryDeli.Data.Domains.Food
            {
                Name = createFoodCommand.CreateFoodModel.Title,
                Description = createFoodCommand.CreateFoodModel.Description,
                Price = createFoodCommand.CreateFoodModel.Price,
                PreparingTime = createFoodCommand.CreateFoodModel.PreparingTime,
                Restaurant = createFoodCommand.Restaurant,
                Image = new Image
                {
                    FileName = "testName",
                    Data = createFoodCommand.CreateFoodModel.Image.ToArray(),
                    Length = createFoodCommand.CreateFoodModel.Image.Count(),
                    ContentType = "image/jpeg",
                },
                FoodFoodTypes = foodTypesRelatesToCommand.Select(ft => new FoodFoodType()
                {
                    FoodType = ft,
                    FoodTypeId = ft.Id
                }).ToList()
            };

            food = await _foodRepository.Add(food);

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
