using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Food : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int PreparingTime { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public Image Image { get; set; }
        public List<FoodFoodType> FoodFoodTypes { get; set; } = new List<FoodFoodType>();
        public List<OrderedFood> OrderedFood { get; set; } = new List<OrderedFood>();
    }
}
