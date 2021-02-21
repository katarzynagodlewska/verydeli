using VeryDeli.Data.Enums;

namespace VeryDeli.Logic.Models.Results.User
{
    public class LoginResult
    {
        public string Token { get; set; }
        public UserType UserTypeId { get; set; }
    }
}
