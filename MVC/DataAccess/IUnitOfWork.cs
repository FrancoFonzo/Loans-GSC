using MVC.DataAccess.Repositories.Category;
using MVC.DataAccess.Repositories.Loan;
using MVC.DataAccess.Repositories.Person;
using MVC.DataAccess.Repositories.Thing;
using MVC.DataAccess.Repositories.User;

namespace MVC.DataAccess
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
