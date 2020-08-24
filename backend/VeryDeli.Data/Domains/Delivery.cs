using System;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Delivery : Entity<Guid>
    {
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
