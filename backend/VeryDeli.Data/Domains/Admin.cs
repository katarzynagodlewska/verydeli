namespace VeryDeli.Data.Domains
{
    public class Admin : User
    {
        public Admin()
        {
            UserTypeId = Enums.UserType.Admin;
        }
    }
}
