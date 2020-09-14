using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class UserTypeRepository : CrudRepository<UserType, Enums.UserType>, IUserTypeRepository
    {
        public UserTypeRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
