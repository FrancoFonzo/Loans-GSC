using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username);

        User Login(string username, string password);
    }
}
