using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Thing
{
    public class ThingRepository : GenericRepository<Entities.Thing>, IThingRepository
    {
        public ThingRepository(LoansContext context) : base(context)
        {

        }

        public IList<Entities.Thing> GetAllWithCategory()
        {
            return dbSet.Include(x => x.Category).ToList();
        }

        public Entities.Thing GetByIdWithCategory(int id)
        {
            return dbSet.Include(x => x.Category).FirstOrDefault(t => t.Id == id)!;
        }
    }
}
