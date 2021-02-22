using VeryDeli.Data.Domains;
using VeryDeli.Logic.Models.Data.Food;

namespace VeryDeli.Logic.Commands.Data.Food
{
    public class CreateFoodCommand : ICommand
    {
        public Restaurant Restaurant { get; set; }
        public FoodModel CreateFoodModel { get; set; }
    }
}
