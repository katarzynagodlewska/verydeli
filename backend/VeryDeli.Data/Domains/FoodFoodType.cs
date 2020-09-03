using System;
using System.ComponentModel.DataAnnotations;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class FoodFoodType : Entity<Guid>
    {
        [Required]
        public Enums.FoodType FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        [Required]
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}
