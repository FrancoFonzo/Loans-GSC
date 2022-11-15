using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(LoansContext context) : base(context)
        {
        }
    }
}
