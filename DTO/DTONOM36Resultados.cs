using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTONOM36Resultados
    {
        public int Transid { get; set; }
        public int Idempleado { get; set; }
        public int Idapartado { get; set; }
        public int Idpregunta { get; set; }
        public int? Idrespuesta { get; set; }
        public int? PesoCarga { get; set; }
        public int? FrecuenciaHora { get; set; }
        public Guid? Idsync { get; set; }
    }
}
