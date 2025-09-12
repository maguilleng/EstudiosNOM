using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVNOM036ResultadosRepository : GenericRepository<NomResultado>, IEVNOM36ResultadosRepository
    {
        public EVNOM036ResultadosRepository(ESTUDIOS_NOM35Context context)
            : base(context)
        { }

    }
}
