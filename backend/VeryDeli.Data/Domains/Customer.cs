using System.Collections.Generic;

namespace VeryDeli.Data.Domains
{
    public class Customer : User
    {
        public Customer()
        {
            UserTypeId = Enums.UserType.Customer;
        }
        public List<Order> Orders { get; set; }
    }
}
