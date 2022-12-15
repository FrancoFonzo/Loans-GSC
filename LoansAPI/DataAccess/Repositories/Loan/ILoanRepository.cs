using LoansAPI.DataAccess.Repositories.Generic;

namespace LoansAPI.DataAccess.Repositories.Loan
{
    public interface ILoanRepository : IGenericRepository<Entities.Loan>
    {
        IList<Entities.Loan> GetAllWithPersonThing();

        Entities.Loan GetByIdWithPersonThing(int id);
    }
}
