using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEvaluacionOnline
    {
        public Guid GuidLink { get; set; }
        public DTOTrabajadoresEvaluados evaluacion { get; set; }
        public DTOEVNutricional nutricional { get; set; }
        public List<DTOEVMuscoloesqueleticos> musculoesqueleticos { get; set; }
    }
}
