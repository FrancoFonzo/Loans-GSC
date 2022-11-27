using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.User
{
    public interface IUserRepository : IGenericRepository<Entities.User>
    {
        Entities.User GetByUsername(string username);

        Entities.User Login(string username, string password);
    }
}
