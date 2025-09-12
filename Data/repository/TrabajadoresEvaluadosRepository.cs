using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;
namespace Data.repository
{
    public class TrabajadoresEvaluadosRepository : GenericRepository<TrabajadoresEstudio>, ITrabajadoresEvaluadosRepository
    {
        public TrabajadoresEvaluadosRepository(ESTUDIOS_NOM35Context context)
            : base(context)
        { }
    
    }
}
