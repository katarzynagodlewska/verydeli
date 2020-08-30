using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeryDeli.Data.Domains
{
    public class Restaurant : User
    {
        public Restaurant()
        {
            UserTypeId = Enums.UserType.Restaurant;
        }

        [Required]
        public  Address Address { get; set; }
        public List<Order> Orders { get; set; }
        public string Name { get; set; }
        public List<Food> MenuList { get; set; }
    }
}
