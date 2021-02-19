using System;
using System.Threading.Tasks;
using VeryDeli.Api.Responses.Food;
using VeryDeli.Data.Domains;
using VeryDeli.Logic.Commands;

namespace VeryDeli.Logic.Commands.Handlers.Interfaces
{
    public interface IFoodCommandHandler : ICommandHandler
    {
        Task<FoodDetailsResponse> Handle(Restaurant restaurantUser, FoodCommand foodCommand);
        Task<FoodDetailsResponse> Handle(Guid id, FoodCommand foodCommand);
        Task<DeleteFoodResponse> Handle(Guid id);
    }
}
