using System;
using VeryDeli.Logic.Models.Data.Food;

namespace VeryDeli.Logic.Commands.Data.Food
{
    public class UpdateFoodCommand : ICommand
    {
        public Guid Id { get; set; }
        public FoodModel FoodModel { get; set; }
    }
}
