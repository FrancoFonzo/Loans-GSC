using MVC.DataAccess.Repositories.Generic;

namespace MVC.DataAccess.Repositories.Loan
{
    public interface ILoanRepository : IGenericRepository<Entities.Loan>
    {
        IList<Entities.Loan> GetAllWithPersonThing();

        Entities.Loan GetByIdWithPersonThing(int id);

        bool SetReturnDate(int id);
    }
}
