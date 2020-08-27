using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeryDeli.Data.Domains
{
    public class Restaurant : User
    {
        public Restaurant()
        {
            UserTypeId = Enums.UserType.Restaurant;
        }
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
        public List<Order> Orders { get; set; }
        public string Name { get; set; }
        public List<Food> MenuList { get; set; }
    }
}
