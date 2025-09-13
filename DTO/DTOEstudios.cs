using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEstudios
    {
        public int Idestudio { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Instalacion { get; set; }
        public DateTime FechaCaptura { get; set; }
        public DateTime? FechaInforme { get; set; }
        public string Rfcempresa { get; set; }
        public string RfcempresaEva { get; set; }
        public bool? GuiaIi { get; set; }
        public bool? GuiaIii { get; set; }
        public bool Activo { get; set; }
        public Guid? Idsync { get; set; }
        public string TipoEstudio { get; set; }
    }
}
