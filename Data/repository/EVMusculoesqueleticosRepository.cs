using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVMusculoesqueleticosRepository : GenericRepository<EvMuscoloesqueletico>, IEVMusculoesqueleticosRepository
    {
        public EVMusculoesqueleticosRepository(ESTUDIOS_NOM35Context context)
        : base(context)
        { }
    }
}
