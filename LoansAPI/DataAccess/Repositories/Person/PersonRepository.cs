using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.Person
{
    public class PersonRepository : GenericRepository<Entities.Person>, IPersonRepository
    {
        public PersonRepository(LoansContext context) : base(context)
        {
        }
    }
}
