using System;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Address : Entity<Guid>
    {
        public string Name { get; set; }
        public AddressPoint AddressPoint { get; set; }
    }
}
