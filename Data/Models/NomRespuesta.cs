using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class NomRespuesta
    {
        public NomRespuesta()
        {
            NomResultados = new HashSet<NomResultado>();
        }

        public int Idrespuesta { get; set; }
        public int Idpregunta { get; set; }
        public int Idapartado { get; set; }
        public int Indice { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        public int? Valor { get; set; }
        public string Imagen { get; set; }
        public string TipoRespuesta { get; set; }
        public string ImagenPregunta { get; set; }

        public virtual NomApartado IdapartadoNavigation { get; set; }
        public virtual NomPregunta IdpreguntaNavigation { get; set; }
        public virtual ICollection<NomResultado> NomResultados { get; set; }
    }
}
