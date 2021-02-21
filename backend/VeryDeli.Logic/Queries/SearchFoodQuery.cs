namespace VeryDeli.Logic.Queries
{
    public class SearchFoodQuery : IQuery
    {
        public string SearchFoodText { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
