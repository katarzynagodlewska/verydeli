using System.Collections.Generic;
using VeryDeli.Logic.Models.Data.Food;

namespace VeryDeli.Logic.Models.Results.Food
{
    public class SearchResult : ExecuteResult
    {
        public List<FoodModel> FoodModels { get; set; }
    }
}
