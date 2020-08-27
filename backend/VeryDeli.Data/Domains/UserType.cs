using VeryDeli.Data.Domains.Base;

namespace VeryDeli.Data.Domains
{
    public class UserType : Entity<Enums.UserType>
    {
        public string Name { get; set; }
    }
}
