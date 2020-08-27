using System;
using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class OrderedFood : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }
    }
}
