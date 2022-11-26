using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LoansContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return dbSet.FirstOrDefault(x => x.Username == username);
        }

        public User Login(string username, string password)
        {
            return dbSet.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
