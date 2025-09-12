using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAYCAmbSonoro
    {
        public int Transid { get; set; }
        public int Idtarea { get; set; }
        public string Intensidad { get; set; }
        public string Continuidad { get; set; }
        public string Fuente { get; set; }
        public string Observaciones { get; set; }
        public Guid? Idsync { get; set; }
    }
}
