using Microsoft.EntityFrameworkCore;
using LoansAPI.DataAccess.Repositories.Generic;
using LoansAPI.Entities;

namespace LoansAPI.DataAccess.Repositories.Loan
{
    public class LoanRepository : GenericRepository<Entities.Loan>, ILoanRepository
    {
        public LoanRepository(LoansContext context) : base(context)
        {
        }

        public IList<Entities.Loan> GetAllWithPersonThing()
        {
            return dbSet.Include(l => l.Person).Include(l => l.Thing).ToList();
        }

        public Entities.Loan GetByIdWithPersonThing(int id)
        {
            return dbSet.Include(l => l.Person).Include(l => l.Thing).FirstOrDefault(l => l.Id == id)!;
        }

        public bool SetReturnDate(int id)
        {
            var loan = GetById(id);
            loan.ReturnDate = DateTime.Now;
            return true;
        }
    }
}
