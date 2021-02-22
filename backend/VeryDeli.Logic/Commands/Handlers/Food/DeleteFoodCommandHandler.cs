using System.Threading.Tasks;
using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Logic.Commands.Data.Food;
using VeryDeli.Logic.Commands.Handlers.Interfaces;
using VeryDeli.Logic.Models;
using VeryDeli.Logic.Models.Results.Food;

namespace VeryDeli.Logic.Commands.Handlers.Food
{
    class DeleteFoodCommandHandler : ICommandHandler
    {
        private readonly IFoodRepository _foodRepository;

        public DeleteFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<ExecuteResult> Handle(ICommand command)
        {
            var deleteFoodCommand = command as DeleteFoodCommand;

            await _foodRepository.RemoveById(deleteFoodCommand.Id);

            return new DeleteFoodResult() { ResponseMessage = "Succcessfully deleted food item" };
        }
    }
}
