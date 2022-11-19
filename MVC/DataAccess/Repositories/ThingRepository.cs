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

        public override IList<Thing> GetAll()
        {
            return dbSet.Include(x => x.Category).ToList();
        }

        public override Thing GetById(int id)
        {
            return dbSet.Include(x => x.Category).FirstOrDefault(t => t.Id == id);
        }

        public override IList<Thing> GetByFilter(Expression<Func<Thing, bool>> filter)
        {
            return dbSet.Where(filter).Include(x => x.Category).ToList();
        }
    }
}
