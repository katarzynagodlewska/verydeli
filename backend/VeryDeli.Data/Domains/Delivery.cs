using System;
using System.ComponentModel.DataAnnotations.Schema;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Delivery : Entity<Guid>
    {
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
    }
}
