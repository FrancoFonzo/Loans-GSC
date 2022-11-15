using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LoansContext context) : base(context)
        {
        }
    }
}
