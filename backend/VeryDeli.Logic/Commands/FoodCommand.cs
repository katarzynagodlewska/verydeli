using System.Collections.Generic;

namespace VeryDeli.Logic.Commands
{
    public class FoodCommand
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int PreparingTime { get; set; }
        public List<byte> Image { get; set; }
        public List<string> FoodTypes { get; set; }
    }
}
