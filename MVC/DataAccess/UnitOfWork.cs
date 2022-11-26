using MVC.DataAccess.Repositories;

namespace MVC.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoansContext context;
        public ICategoryRepository CategoriesRepository { get; init; }
        public IPersonRepository PeopleRepository { get; init; }
        public IThingRepository ThingsRepository { get; init;  }
        public ILoanRepository LoansRepository { get; init; }
        public IUserRepository UsersRepository { get; init; }


        public UnitOfWork(LoansContext context)
        {
            this.context = context;
            CategoriesRepository = new CategoryRepository(this.context);
            PeopleRepository = new PersonRepository(this.context);
            ThingsRepository = new ThingRepository(this.context);
            LoansRepository = new LoanRepository(this.context);
            UsersRepository = new UserRepository(this.context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }   
    }
}
