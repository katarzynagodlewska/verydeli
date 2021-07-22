using System;
using VeryDeli.Libraries.Abstraction.Repository;
using VeryDeli.Modules.Users.Core.Data.Domains;

namespace VeryDeli.Modules.Users.Core.Repository.Abstraction
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
