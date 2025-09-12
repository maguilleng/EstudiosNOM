using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTONOM036Preguntas
    {
        public int IdPregunta { get; set; }
        public int IdApartado { get; set; }
        public int? IdseccionPregunta { get; set; }
        public int? DependeDe { get; set; }
        public int Indice { get; set; }
        public string Titulo{ get; set; }
        public string Descripcion { get; set; }
        public string TipoPregunta { get; set; }
        public List<DTONOM036Respuestas> Respuestas { get; set; }
    }
}
