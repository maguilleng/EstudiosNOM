using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class NomResultado
    {
        public int Transid { get; set; }
        public int Idempleado { get; set; }
        public int Idapartado { get; set; }
        public int Idpregunta { get; set; }
        public int? Idrespuesta { get; set; }
        public int? PesoCarga { get; set; }
        public int? FrecuenciaHora { get; set; }
        public Guid? Idsync { get; set; }

        public virtual NomApartado IdapartadoNavigation { get; set; }
        public virtual TrabajadoresEstudio IdempleadoNavigation { get; set; }
        public virtual NomPregunta IdpreguntaNavigation { get; set; }
        public virtual NomRespuesta IdrespuestaNavigation { get; set; }
    }
}
