namespace VeryDeli.Logic.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
