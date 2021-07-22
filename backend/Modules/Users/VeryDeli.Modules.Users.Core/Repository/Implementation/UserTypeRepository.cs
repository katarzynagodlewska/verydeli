using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Libraries.Infrastructure.Repository;
using VeryDeli.Modules.Users.Core.Data;
using VeryDeli.Modules.Users.Core.Data.Domains;

namespace VeryDeli.Data.Repositories.Implementation
{
    public class UserTypeRepository : CrudRepository<UserType, Modules.Users.Core.Data.Enums.UserType>, IUserTypeRepository
    {
        public UserTypeRepository(UserModuleDatabaseContext context) : base(context)
        {
        }
    }
}
