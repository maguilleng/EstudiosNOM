using Data.repositoryInterface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

    namespace Data.repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly ESTUDIOS_NOM35Context context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(ESTUDIOS_NOM35Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            T result = dbSet.Add(entity).Entity;
            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await dbSet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }

        public T Delete(T entity)
        {
            entity = dbSet.Remove(entity).Entity;
            return entity;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params string[] properties)
        {
            var result = dbSet.Where(predicate);

            if (properties != null)
            {
                foreach (var item in properties)
                    result = result.Include(item);
            }

            return result.AsEnumerable();
        }

        public IEnumerable<T> GetAll(params string[] properties)
        {
            var result = dbSet.AsQueryable();
            if (properties != null)
            {
                foreach (var item in properties)
                    result = result.Include(item);
            }

            return result.AsEnumerable();
        }

        public T Update(T entity)
        {
            entity = dbSet.Update(entity).Entity;
            return entity;
        }
    }
}
