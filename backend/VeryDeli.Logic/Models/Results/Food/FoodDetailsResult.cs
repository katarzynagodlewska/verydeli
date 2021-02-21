using System;

namespace VeryDeli.Logic.Models.Results.Food
{
    public class FoodDetailsResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PreparingTime { get; set; }
        public byte[] Image { get; set; }
    }
}
