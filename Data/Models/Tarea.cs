using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Tarea
    {
        public int Idtarea { get; set; }
        public int? Idactividad { get; set; }
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

        public virtual Actividade IdactividadNavigation { get; set; }
        public virtual EvAycAmbientermico EvAycAmbientermico { get; set; }
        public virtual EvAycAmbientesonoro EvAycAmbientesonoro { get; set; }
        public virtual EvAycIluminacion EvAycIluminacion { get; set; }
        public virtual EvAycVibracion EvAycVibracion { get; set; }
    }
}
