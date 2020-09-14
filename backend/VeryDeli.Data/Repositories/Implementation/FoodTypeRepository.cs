using System;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class FoodTypeRepository : CrudRepository<FoodType, Guid>, IFoodTypeRepository
    {
        public FoodTypeRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
