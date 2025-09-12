using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    public class GenericBusiness<Tdto, Tentity> : IGenericBusiness<Tdto>
        where Tdto : class, new()
        where Tentity : class, new()
    {
        protected readonly ESTUDIOS_NOM35Context context;
        protected readonly IGenericRepository<Tentity> repository;
        protected readonly IMapper mapper;

        public GenericBusiness(ESTUDIOS_NOM35Context context, IGenericRepository<Tentity> repository, IMapper mapper)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        public Tdto Add(Tdto dto)
        {
            Tentity entity = mapper.Map<Tentity>(dto);
            entity = repository.Add(entity);
            context.SaveChanges();
            return mapper.Map<Tdto>(entity);
        }

        public List<Tdto> Add(List<Tdto> dto)
        {
            List<Tentity> entities = new List<Tentity>();

            dto.ForEach(entry =>
            {
                Tentity entity = mapper.Map<Tentity>(entry);
                entity = repository.Add(entity);
                entities.Add(entity);
            });

            context.SaveChanges();
            return mapper.Map<List<Tdto>>(entities);
        }

        public async Task<Tdto> AddAsync(Tdto dto)
        {
            Tentity entity = mapper.Map<Tentity>(dto);
            entity = await repository.AddAsync(entity);
            return mapper.Map<Tdto>(entity);
        }

        public Tdto Delete(Tdto dto)
        {
            Tentity entity = mapper.Map<Tentity>(dto);
            entity = repository.Delete(entity);
            context.SaveChanges();
            return mapper.Map<Tdto>(entity);
        }

        public IEnumerable<Tdto> FindBy(System.Linq.Expressions.Expression<Func<Tentity, bool>> predicate, params string[] properties)
        {
            var result = repository.FindBy(predicate, properties);

            return mapper.Map<IEnumerable<Tdto>>(result);
        }

        public IEnumerable<Tdto> GetAll(params string[] properties)
        {
            var result = repository.GetAll(properties);
            return mapper.Map<IEnumerable<Tdto>>(result.ToList());
        }

        public Tdto Update(Tdto dto)
        {
            Tentity entity = mapper.Map<Tentity>(dto);
            entity = repository.Update(entity);
            context.SaveChanges();
            return mapper.Map<Tdto>(entity);
        }

        public List<Tdto> Update(List<Tdto> dto)
        {
            List<Tentity> entities = new List<Tentity>();

            dto.ForEach(entry =>
            {
                Tentity entity = mapper.Map<Tentity>(entry);
                entity = repository.Update(entity);
            });

            context.SaveChanges();
            return mapper.Map<List<Tdto>>(entities);
        }
    }
}
