using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Nom036Respuesta
    {
        public Nom036Respuesta()
        {
            Nom036Resultados = new HashSet<Nom036Resultado>();
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
        public virtual Nom036Pregunta IdpreguntaNavigation { get; set; }
        public virtual ICollection<Nom036Resultado> Nom036Resultados { get; set; }
    }
}
