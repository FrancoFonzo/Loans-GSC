using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(LoansContext context) : base(context)
        {
        }
    }
}
