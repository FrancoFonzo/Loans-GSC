using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.Category
{
    public class CategoryRepository : GenericRepository<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(LoansContext context) : base(context)
        {
        }
    }
}
