using System;
using System.Threading.Tasks;
using VeryDeli.Api.Responses.Food;

namespace VeryDeli.Api.Commands.Handlers.Interfaces
{
    public interface IFoodCommandHandler : ICommandHandler
    {
        Task<FoodDetailsResponse> Handle(FoodCommand foodCommand);
        Task<FoodDetailsResponse> Handle(Guid id, FoodCommand foodCommand);
        Task<DeleteFoodResponse> Handle(Guid id);
    }
}
