using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEVNutricional
    {
        public int Transid { get; set; }
        public int Idempleado { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal PerimetroAbdominal { get; set; }
        public decimal Ims { get; set; }
        public Guid? Idsync { get; set; }
    }
}
