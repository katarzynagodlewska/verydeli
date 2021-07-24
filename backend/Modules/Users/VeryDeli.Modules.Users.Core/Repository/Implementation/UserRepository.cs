using System;
using VeryDeli.Libraries.Infrastructure.Repository;
using VeryDeli.Modules.Users.Core.Data;
using VeryDeli.Modules.Users.Core.Data.Domains;
using VeryDeli.Modules.Users.Core.Repository.Abstraction;

namespace VeryDeli.Modules.Users.Core.Repository.Implementation
{
    public class UserRepository : CrudRepository<User, Guid>, IUserRepository
    {
        public UserRepository(UserModuleDatabaseContext context) : base(context)
        {
        }
    }
}
