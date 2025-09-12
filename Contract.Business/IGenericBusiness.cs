using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Business
{
    public interface IGenericBusiness<Tdto>
        where Tdto : class, new()
    {
        IEnumerable<Tdto> GetAll(params string[] properties);

        Tdto Add(Tdto dto);

        Task<Tdto> AddAsync(Tdto dto);

        Tdto Delete(Tdto dto);

        Tdto Update(Tdto dto);

        //Agregada por mi
        //IEnumerable<Tdto> FindBy(System.Linq.Expressions.Expression<Func<Tentity, bool>> predicate, params string[] properties);

        List<Tdto> Add(List<Tdto> dto);

        List<Tdto> Update(List<Tdto> dto);
    }
}