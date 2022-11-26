using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Category
{
    public class CategoryRepository : GenericRepository<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(LoansContext context) : base(context)
        {
        }
    }
}
