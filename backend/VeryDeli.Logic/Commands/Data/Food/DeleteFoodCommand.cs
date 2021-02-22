using System;

namespace VeryDeli.Logic.Commands.Data.Food
{
    public class DeleteFoodCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
