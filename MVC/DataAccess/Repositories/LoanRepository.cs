using Microsoft.EntityFrameworkCore;
using MVC.Entities;

namespace MVC.DataAccess.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(LoansContext context) : base(context)
        {
        }

        public IList<Loan> GetAllWithPersonThing()
        {
            return dbSet.Include(l => l.Person).Include(l => l.Thing).ToList();
        }

        public Loan GetByIdWithPersonThing(int id)
        {
            return dbSet.Include(l => l.Person).Include(l => l.Thing).FirstOrDefault(l => l.Id == id);
        }

        public bool SetReturnDate(int id)
        {
            var loan = GetById(id);
            loan.ReturnDate = DateTime.Now;
            return true;
        }
    }
}
