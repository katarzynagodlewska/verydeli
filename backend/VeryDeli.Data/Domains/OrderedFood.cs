using System;
using System.ComponentModel.DataAnnotations;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class OrderedFood : Entity<Guid>
    {
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}
