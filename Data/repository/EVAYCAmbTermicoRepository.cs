using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVAYCAmbTermicoRepository : GenericRepository<EvAycAmbientermico>, IEVAYCAmbTermicoRepository
    {
        public EVAYCAmbTermicoRepository(ESTUDIOS_NOM35Context context)
        : base(context)
        { }
    }
}
