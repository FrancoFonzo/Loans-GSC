using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Thing
{
    public interface IThingRepository : IGenericRepository<Entities.Thing>
    {
        IList<Entities.Thing> GetAllWithCategory();
        Entities.Thing GetByIdWithCategory(int id);
    }
}
