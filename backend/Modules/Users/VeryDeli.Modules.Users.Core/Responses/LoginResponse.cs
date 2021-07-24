using VeryDeli.Modules.Users.Core.Data.Enums;

namespace VeryDeli.Modules.Users.Core.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserType UserTypeId { get; set; }
    }
}
