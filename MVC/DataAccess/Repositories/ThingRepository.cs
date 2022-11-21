using Microsoft.EntityFrameworkCore;
using MVC.Entities;
using System.Linq.Expressions;

namespace MVC.DataAccess.Repositories
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(LoansContext context) : base(context)
        {
            
        }

        public IList<Thing> GetAllWithCategory()
        {
            return dbSet.Include(x => x.Category).ToList();
        }

        public Thing GetByIdWithCategory(int id)
        {
            return dbSet.Include(x => x.Category).FirstOrDefault(t => t.Id == id)!;
        }
    }
}
