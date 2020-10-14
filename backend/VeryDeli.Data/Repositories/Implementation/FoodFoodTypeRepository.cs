using System;
using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class FoodFoodTypeRepository : CrudRepository<FoodFoodType, Guid>, IFoodFoodTypeRepository
    {
        public FoodFoodTypeRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
