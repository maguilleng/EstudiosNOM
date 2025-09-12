using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAYCVibracion
    {
        public int Transid { get; set; }
        public int? Idtarea { get; set; }
        public string Intensidad { get; set; }
        public string SegmentosCorporales { get; set; }
        public string CualSegmentario { get; set; }
        public string Observaciones { get; set; }
        public Guid? Idsync { get; set; }
    }
}
