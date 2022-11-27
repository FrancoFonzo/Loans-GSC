using LoansAPI.DataAccess.Repositories.Category;
using LoansAPI.DataAccess.Repositories.Loan;
using LoansAPI.DataAccess.Repositories.Person;
using LoansAPI.DataAccess.Repositories.Thing;
using LoansAPI.DataAccess.Repositories.User;

namespace LoansAPI.DataAccess
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoriesRepository { get; init; }
        public IPersonRepository PeopleRepository { get; init; }
        public IThingRepository ThingsRepository { get; init; }
        public ILoanRepository LoansRepository { get; init; }
        public IUserRepository UsersRepository { get; init; }

        public int SaveChanges();
    }
}
