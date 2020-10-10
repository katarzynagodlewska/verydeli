using System;
using System.Threading.Tasks;
using VeryDeli.Api.Commands.Handlers.Interfaces;
using VeryDeli.Api.Responses.Food;

namespace VeryDeli.Api.Commands.Handlers
{
    public class FoodCommandHandler : IFoodCommandHandler
    {
        public async Task<FoodDetailsResponse> Handle(FoodCommand foodCommand)
        {
            throw new NotImplementedException();
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
