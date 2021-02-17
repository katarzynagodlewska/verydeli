namespace VeryDeli.Api.Responses.User
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public Data.Enums.UserType UserTypeId { get; set; }
    }
}
