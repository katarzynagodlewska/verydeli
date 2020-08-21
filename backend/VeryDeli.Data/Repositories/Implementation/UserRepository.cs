using VeryDeli.Data.Domains;
using VeryDeli.Data.Repositories.Abstraction;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(VeryDeliDataContext context) : base(context)
        {
        }
    }
}
