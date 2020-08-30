using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Order : Entity<Guid>
    {
        public Courier CourierUser { get; set; }
        [Required]
        public Restaurant RestaurantUser { get; set; }
        [Required]
        public Customer ReceiverUser { get; set; }
        public List<OrderedFood> OrderedFood { get; set; } = new List<OrderedFood>();
        [Required]
        public Delivery Delivery { get; set; }
    }
}
