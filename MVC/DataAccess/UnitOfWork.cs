using MVC.DataAccess.Repositories;

namespace MVC.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoansContext context;
        public ICategoryRepository CategoryRepository { get; init; }
        public IPersonRepository PeopleRepository { get; init; }
        public IThingRepository ThingsRepository { get; init;  }

        public UnitOfWork(LoansContext context)
        {
            this.context = context;
            CategoryRepository = new CategoryRepository(this.context);
            PeopleRepository = new PersonRepository(this.context);
            ThingsRepository = new ThingRepository(this.context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }   
    }
}
