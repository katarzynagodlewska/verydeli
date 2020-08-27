using System;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class Address : Entity<Guid>
    {
        public string Name { get; set; }
        public double XCordinate { get; set; }
        public double YCordinate { get; set; }
    }
}
