using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;


namespace Data.repository
{
    public class TareasRepository : GenericRepository<Tarea>, ITareasRepository
    {
        public TareasRepository(ESTUDIOS_NOM35Context context)
        : base(context)
        { }
    }
    }
