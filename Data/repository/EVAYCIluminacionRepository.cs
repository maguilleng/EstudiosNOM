using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVAYCIluminacionRepository : GenericRepository<EvAycIluminacion>, IEVAYCIluminacionRepository
    {
        public EVAYCIluminacionRepository(ESTUDIOS_NOM35Context context)
        : base(context)
        { }
    }
}
