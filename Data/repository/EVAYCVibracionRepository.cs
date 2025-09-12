using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVAYCVibracionRepository : GenericRepository<EvAycVibracion>, IEVAYCVibracionRepository
    {
        public EVAYCVibracionRepository(ESTUDIOS_NOM35Context context)
        : base(context)
        { }
    }
}
