using System.Collections.Generic;
using VeryDeli.Api.Models;

namespace VeryDeli.Api.Responses.Food
{
    public class SearchResponse
    {
        public List<FoodModel> FoodModels { get; set; }
    }
}
