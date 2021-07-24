using VeryDeli.Data.Repositories.Abstraction;
using VeryDeli.Libraries.Infrastructure.Repository;
using VeryDeli.Modules.Users.Core.Data;
using VeryDeli.Modules.Users.Core.Data.Domains;

namespace VeryDeli.Modules.Users.Core.Repository.Implementation
{
    public class UserTypeRepository : CrudRepository<UserType, Data.Enums.UserType>, IUserTypeRepository
    {
        public UserTypeRepository(UserModuleDatabaseContext context) : base(context)
        {
        }
    }
}
