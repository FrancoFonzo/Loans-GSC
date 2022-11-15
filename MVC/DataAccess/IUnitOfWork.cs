using MVC.DataAccess.Repositories;

namespace MVC.DataAccess
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; init; }
        public IPersonRepository PeopleRepository { get; init; }
        public IThingRepository ThingsRepository { get; init; }

        public int SaveChanges();
    }
}
