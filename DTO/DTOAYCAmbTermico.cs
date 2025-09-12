using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAYCAmbTermico
    {
        public int Transid { get; set; }
        public int IDTarea { get; set; }
        public string Percepcion { get; set; }
        public string EjemploPercepcion { get; set; }
        public string Intensidad { get; set; }
        public string Fuente { get; set; }
        public string Observaciones { get; set; }
        public Guid? Idsync { get; set; }
    }
}
