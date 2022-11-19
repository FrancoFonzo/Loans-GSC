using Microsoft.EntityFrameworkCore;
using MVC.Entities;
using System.Linq.Expressions;

namespace MVC.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LoansContext context) : base(context)
        {
        }

        public override IList<Category> GetAll()
        {
            return dbSet.Include(c => c.Things).ToList();
        }

        public override Category GetById(int id)
        {
            return dbSet.Include(c => c.Things).FirstOrDefault(c => c.Id == id);
        }

        public override IList<Category> GetByFilter(Expression<Func<Category, bool>> filter)
        {
            return dbSet.Where(filter).Include(x => x.Things).ToList();
        }
    }
}
