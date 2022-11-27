using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.Thing
{
    public interface IThingRepository : IGenericRepository<Entities.Thing>
    {
        IList<Entities.Thing> GetAllWithCategory();
        Entities.Thing GetByIdWithCategory(int id);
    }
}
