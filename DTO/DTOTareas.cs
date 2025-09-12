using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public  class DTOTareas
    {
        public int Idtarea { get; set; }
        public int Idactividad { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TiempoTarea { get; set; }
        public string Ubicacion { get; set; }
        public string Frecuencia { get; set; }
        public string TipoTarea { get; set; }
        public bool? Colectiva { get; set; }
        public bool? Evnom036Transportar { get; set; }
        public bool? Evnom036Levantar { get; set; }
        public bool? Evnom036Equipo { get; set; }
        public bool? EvagentesCondiciones { get; set; }
        public bool? Reba { get; set; }
        public bool? Rula { get; set; }
        public bool? Niosh { get; set; }
        public bool? Owas { get; set; }
        public bool? Rosa { get; set; }
        public bool? Activo { get; set; }
        public Guid? Idsync { get; set; }

    }
}
