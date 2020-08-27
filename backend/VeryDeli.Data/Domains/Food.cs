using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Food : Entity<Guid>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
        public List<OrderedFood> OrderedFood { get; set; } = new List<OrderedFood>();
    }
}
