using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        IList<Loan> GetAllWithPersonThing();

        Loan GetByIdWithPersonThing(int id);

        bool SetReturnDate(int id);
    }
}
