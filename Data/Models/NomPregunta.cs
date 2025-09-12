using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class NomPregunta
    {
        public NomPregunta()
        {
            NomRespuesta = new HashSet<NomRespuesta>();
            NomResultados = new HashSet<NomResultado>();
        }

        public int Idpregunta { get; set; }
        public int Idapartado { get; set; }
        public int? IdseccionPregunta { get; set; }
        public int? DependeDe { get; set; }
        public int Indice { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TipoPregunta { get; set; }

        public virtual NomApartado IdapartadoNavigation { get; set; }
        public virtual ICollection<NomRespuesta> NomRespuesta { get; set; }
        public virtual ICollection<NomResultado> NomResultados { get; set; }
    }
}
