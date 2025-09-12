using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOGetCuestionarioNOM36
    {
           public int  IdApartado  {get; set;} 
           public int?  Indice  {get; set;}
           public string Titulo { get; set; }
            public string   Descripción  {get; set;} 
            public int  IdPregunta  {get; set;} 
            public int  IdApartadoPregunta  {get; set;} 
        public int IndicePregunta  {get; set;} 
        public string TipoPregunta { get; set; }
        public string  TituloPregunta  {get; set;} 
        public string  DescripcionPregunta  {get; set; }
        public int? IdseccionPregunta { get; set; }
        public int? DependeDe { get; set; }
        public int  IdRespuesta  {get; set;}
        public int  IDpreguntaResp {get; set;}
        public int IdApartadoResp  {get; set;}
        public int  IndiceResp  {get; set;} 
        public string DescripcionResp  {get; set;}
        public string  Nivel  {get; set;}
        public int?   Valor  {get; set;} 
        public string  Imagen  {get; set; }
        public string TipoRespuesta { get; set; }
        public string ImagenPregunta { get; set; }
        public int?  IdRespSeleccionada { get; set; }
        public int? PesoCarga { get; set; }
        public int? FrecuenciaHora { get; set; }
        public int? TRANSID { get; set; }
    }
}
