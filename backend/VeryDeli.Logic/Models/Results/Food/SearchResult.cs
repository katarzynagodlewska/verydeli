using System.Collections.Generic;

namespace VeryDeli.Logic.Models.Results.Food
{
    public class SearchResult : ExecuteResult
    {
        public List<FoodModel> FoodModels { get; set; }
    }
}
