using System;
using System.Collections.Generic;

namespace VeryDeli.Api.Responses.Home
{
    public class HomeFoodsResponse
    {
        public List<HomeFoodModel> HomeFoodModels { get; set; }
    }

    public class HomeFoodModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
