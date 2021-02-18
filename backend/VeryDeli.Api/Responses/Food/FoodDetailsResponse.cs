using System;

namespace VeryDeli.Api.Responses.Food
{
    public class FoodDetailsResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PreparingTime { get; set; }
        public byte[] Image { get; set; }
    }
}
