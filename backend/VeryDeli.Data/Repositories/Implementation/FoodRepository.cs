using System;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class FoodRepository: CrudRepository<Food,Guid>, IFoodRepository
    {
        public FoodRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
