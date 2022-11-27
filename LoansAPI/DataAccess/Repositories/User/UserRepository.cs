using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.User
{
    public class UserRepository : GenericRepository<Entities.User>, IUserRepository
    {
        public UserRepository(LoansContext context) : base(context)
        {
        }

        public Entities.User GetByUsername(string username)
        {
            return dbSet.FirstOrDefault(x => x.Username == username)!;
        }

        public Entities.User Login(string username, string password)
        {
            return dbSet.FirstOrDefault(x => x.Username == username && x.Password == password)!;
        }
    }
}
