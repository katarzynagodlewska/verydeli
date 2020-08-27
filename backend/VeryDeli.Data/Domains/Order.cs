using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Order : Entity<Guid>
    {
        public Guid CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public virtual Courier Courier { get; set; }
        public Guid RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
        public Guid ReceiverId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public virtual Customer Receiver { get; set; }
        public List<OrderedFood> OrderedFood { get; set; } = new List<OrderedFood>();
        public Guid DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public virtual Delivery Delivery { get; set; }
    }
}
