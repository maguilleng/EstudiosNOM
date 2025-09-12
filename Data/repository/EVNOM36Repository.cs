using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class EVNOM36Repository : GenericRepository<NomApartado>, IEVNOM36Repository
    {
        public EVNOM36Repository(ESTUDIOS_NOM35Context context)
            : base(context)
        { }

    }
}
