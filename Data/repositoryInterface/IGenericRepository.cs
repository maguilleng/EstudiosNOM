using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Data.repositoryInterface
{
    public interface IGenericRepository<T>
       where T : class
    {
        IEnumerable<T> GetAll(params string[] properties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params string[] properties);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        T Delete(T entity);

        T Update(T entity);
    }
}
