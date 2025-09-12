using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEvaluacionOffline
    {
        public DTOTrabajadoresEvaluados evaluacion { get; set; }
        public List<DTONOM36Resultados> resultados { get; set; }
    }
}
