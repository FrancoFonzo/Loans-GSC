using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Person
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(LoansContext context) : base(context)
        {
        }
    }
}
