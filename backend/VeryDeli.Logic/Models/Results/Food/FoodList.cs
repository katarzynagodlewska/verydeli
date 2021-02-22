using System.Collections.Generic;

namespace VeryDeli.Logic.Models.Results.Food
{
    public class FoodList : ExecuteResult
    {
        public List<FoodListItem> FoodListItems { get; set; }
    }
}
