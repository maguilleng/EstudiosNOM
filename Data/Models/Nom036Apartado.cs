using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Nom036Apartado
    {
        public Nom036Apartado()
        {
            Nom036Pregunta = new HashSet<Nom036Pregunta>();
            Nom036Respuesta = new HashSet<Nom036Respuesta>();
            Nom036Resultados = new HashSet<Nom036Resultado>();
        }

        public int Idapartado { get; set; }
        public int? Indice { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Nom036Pregunta> Nom036Pregunta { get; set; }
        public virtual ICollection<Nom036Respuesta> Nom036Respuesta { get; set; }
        public virtual ICollection<Nom036Resultado> Nom036Resultados { get; set; }
    }
}
