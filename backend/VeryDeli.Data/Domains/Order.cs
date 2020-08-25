using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Order : Entity<Guid>
    {
        public DateTime ExpectedDeliveryTime { get; set; }
        public Guid CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public virtual User Courier { get; set; }
        public Guid RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
        public Guid ReceiverId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public virtual User Receiver { get; set; }
        public List<Food> OrderedFood { get; set; } = new List<Food>();
    }
}
