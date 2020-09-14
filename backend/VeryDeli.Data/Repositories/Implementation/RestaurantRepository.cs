using System;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class RestaurantRepository : CrudRepository<Restaurant, Guid>, IRestaurantRepository
    {
        public RestaurantRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
