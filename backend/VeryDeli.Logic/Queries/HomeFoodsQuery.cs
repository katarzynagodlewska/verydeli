using VeryDeli.Data.Enums;

namespace VeryDeli.Logic.Queries
{
    public class HomeFoodsQuery : IQuery
    {
        public FoodType FoodType { get; set; }
    }
}
