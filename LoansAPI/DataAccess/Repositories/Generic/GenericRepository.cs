using Microsoft.EntityFrameworkCore;
using LoansAPI.Entities;
using System.Linq.Expressions;

namespace LoansAPI.DataAccess.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly LoansContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(LoansContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IList<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter).ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.FirstOrDefault(t => t.Id == id)!;
        }

        public T Create(T entity)
        {
            var savedEntity = dbSet.Add(entity);
            return savedEntity.Entity;
        }

        public T Update(T entity)
        {
            var savedEntity = dbSet.Update(entity);
            return savedEntity.Entity;
        }

        public void Delete(int id)
        {
            var entityToDelete = GetById(id);
            dbSet.Remove(entityToDelete);
        }

        public bool Exists(Expression<Func<T, bool>> filter)
        {
            return dbSet.Any(filter);
        }
    }
}
