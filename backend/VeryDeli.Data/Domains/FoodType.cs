using System.Collections.Generic;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class FoodType : Entity<Enums.FoodType>
    {
        public List<FoodFoodType> FoodFoodTypes { get; set; } = new List<FoodFoodType>();
    }
}
