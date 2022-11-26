using MVC.Entities;
using System.Linq.Expressions;

namespace MVC.DataAccess.Repositories.Generic
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IList<T> GetAll();
        IList<T> GetByFilter(Expression<Func<T, bool>> filter);
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
        bool Exists(Expression<Func<T, bool>> filter);
    }
}
