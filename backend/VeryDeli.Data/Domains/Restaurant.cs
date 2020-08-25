using System;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Restaurant : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
