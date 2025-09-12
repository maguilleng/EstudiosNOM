using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EstudiosRepository : GenericRepository<Estudio>, IEstudiosRepository
    {
        public EstudiosRepository(ESTUDIOS_NOM35Context context)
          : base(context)
        { }
    }
}