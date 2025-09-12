using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository 
{
    public class EmpresasRepository : GenericRepository<Empresa>, IEmpresasRepository
    {
        public EmpresasRepository(ESTUDIOS_NOM35Context context)
            : base(context)
        { }
    }
}
