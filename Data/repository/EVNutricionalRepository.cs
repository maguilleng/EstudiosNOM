using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVNutricionalRepository : GenericRepository<EvEstadoNutricional>, IEVNutricionalRepository
    {
          public EVNutricionalRepository(ESTUDIOS_NOM35Context context)
          : base(context)
    { }
    }
}
