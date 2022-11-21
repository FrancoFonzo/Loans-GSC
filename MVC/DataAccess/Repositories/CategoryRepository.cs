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
    }
}
