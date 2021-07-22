using VeryDeli.Libraries.Abstraction.Repository;
using VeryDeli.Modules.Users.Core.Data.Domains;

namespace VeryDeli.Data.Repositories.Abstraction
{
    public interface IUserTypeRepository : IRepository<UserType, Modules.Users.Core.Data.Enums.UserType>
    {
    }
}
