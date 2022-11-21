using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public interface IThingRepository : IGenericRepository<Thing>
    {
        IList<Thing> GetAllWithCategory();
        Thing GetByIdWithCategory(int id);
    }
}
