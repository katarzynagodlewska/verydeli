using System.ComponentModel.DataAnnotations.Schema;

namespace VeryDeli.Modules.Users.Core.Data.Domains
{
    public class UserType
    {
        [Column(Order = 0)]
        public Enums.UserType Id { get; set; }
        public string Name { get; set; }
    }
}
