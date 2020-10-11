namespace VeryDeli.Api.Commands
{
    public class FoodCommand
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PreparingTime { get; set; }
        public byte[] Image { get; set; }
        public string FoodTypes { get; set; }
    }
}
