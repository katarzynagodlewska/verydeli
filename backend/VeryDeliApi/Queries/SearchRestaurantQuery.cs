using System;

namespace VeryDeli.Api.Queries
{
    public class SearchRestaurantQuery
    {
        public Guid RestaurantId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
