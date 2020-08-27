using System;
using System.ComponentModel.DataAnnotations.Schema;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Delivery : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
    }
}
