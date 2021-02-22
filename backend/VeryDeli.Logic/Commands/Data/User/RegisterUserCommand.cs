namespace VeryDeli.Logic.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
