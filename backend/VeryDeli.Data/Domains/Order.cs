using System;
using System.Collections.Generic;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Order : Entity<Guid>
    {
        public DateTime ExpectedDeliveryTime { get; set; }
        public Guid CourierId { get; set; }
        public virtual User Courier { get; set; }
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public Guid ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
        public List<Food> OrderedFood { get; set; } = new List<Food>();
    }
}
