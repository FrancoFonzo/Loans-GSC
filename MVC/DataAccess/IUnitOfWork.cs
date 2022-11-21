using MVC.DataAccess.Repositories;

namespace MVC.DataAccess
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoriesRepository { get; init; }
        public IPersonRepository PeopleRepository { get; init; }
        public IThingRepository ThingsRepository { get; init; }
        public ILoanRepository LoansRepository { get; init; }

        public int SaveChanges();
    }
}
