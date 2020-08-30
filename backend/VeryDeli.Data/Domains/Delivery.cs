using System;
using System.ComponentModel.DataAnnotations;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Delivery : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Address Address { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
    }
}
