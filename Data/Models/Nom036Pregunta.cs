using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Nom036Pregunta
    {
        public Nom036Pregunta()
        {
            Nom036Respuesta = new HashSet<Nom036Respuesta>();
            Nom036Resultados = new HashSet<Nom036Resultado>();
        }

        public int Idpregunta { get; set; }
        public int Idapartado { get; set; }
        public int Indice { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TipoPregunta { get; set; }

        public virtual NomApartado IdapartadoNavigation { get; set; }
        public virtual ICollection<Nom036Respuesta> Nom036Respuesta { get; set; }
        public virtual ICollection<Nom036Resultado> Nom036Resultados { get; set; }
    }
}
