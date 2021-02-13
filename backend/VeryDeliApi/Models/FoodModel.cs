﻿using System;
using System.Collections.Generic;
using VeryDeli.Data.Enums;

namespace VeryDeli.Api.Models
{
    public class FoodModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<FoodType> FoodTypes { get; set; }
    }
}
