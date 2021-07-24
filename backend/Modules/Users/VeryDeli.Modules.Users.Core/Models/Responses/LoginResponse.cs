using VeryDeli.Modules.Users.Core.Data.Enums;

namespace VeryDeli.Modules.Users.Core.Models.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserType UserTypeId { get; set; }
    }
}
