using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class NomApartado
    {
        public NomApartado()
        {
            NomPregunta = new HashSet<NomPregunta>();
            NomRespuesta = new HashSet<NomRespuesta>();
            NomResultados = new HashSet<NomResultado>();
        }

        public int Idapartado { get; set; }
        public string Norma { get; set; }
        public int? Indice { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<NomPregunta> NomPregunta { get; set; }
        public virtual ICollection<NomRespuesta> NomRespuesta { get; set; }
        public virtual ICollection<NomResultado> NomResultados { get; set; }
    }
}
