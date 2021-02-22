using System;
using System.Collections.Generic;
using VeryDeli.Data.Enums;

namespace VeryDeli.Logic.Models.Data.Food
{
    public class FoodModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PreparingTime { get; set; }
        public byte[] Image { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
}
