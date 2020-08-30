using System.Collections.Generic;

namespace VeryDeli.Data.Domains
{
    public class Courier : User
    {
        public Courier()
        {
            UserTypeId = Enums.UserType.Courier;
        }
        public List<Order> Orders { get; set; }
    }
}
