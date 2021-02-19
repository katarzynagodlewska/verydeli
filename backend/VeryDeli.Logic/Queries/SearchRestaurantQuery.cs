using System;

namespace VeryDeli.Logic.Queries
{
    public class SearchRestaurantQuery
    {
        public Guid RestaurantId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
