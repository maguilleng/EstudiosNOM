using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Nom036Resultado
    {
        public int Transid { get; set; }
        public int Idtarea { get; set; }
        public int Idapartado { get; set; }
        public int Idpregunta { get; set; }
        public int? Idrespuesta { get; set; }
        public int? PesoCarga { get; set; }
        public int? FrecuenciaHora { get; set; }
        public Guid? Idsync { get; set; }

        public virtual NomApartado IdapartadoNavigation { get; set; }
        public virtual Nom036Pregunta IdpreguntaNavigation { get; set; }
        public virtual Nom036Respuesta IdrespuestaNavigation { get; set; }
        public virtual Tarea IdtareaNavigation { get; set; }
    }
}
