using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTONOM036Respuestas
    {       
        public int IdRespuesta { get; set; }
        public int IDpregunta { get; set; }
        public int IdApartado { get; set; }
        public int Indice { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        public int? Valor { get; set; }
        public string Imagen { get; set; }

        public string TipoRespuesta { get; set; }
        public string ImagenPregunta { get; set; }
        public string IdRespSeleccionada { get; set; }
        public int? PesoCarga { get; set; }
        public int? FrecuenciaHora { get; set; }
        public int? TRANSID { get; set; }
    }
}
