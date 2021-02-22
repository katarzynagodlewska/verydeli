using System.Collections.Generic;
using VeryDeli.Logic.Models.Data.Food;

namespace VeryDeli.Logic.Models.Results.Food
{
    public class HomeFoodsResult : ExecuteResult
    {
        public List<FoodModel> FoodModels { get; set; }
    }
}
