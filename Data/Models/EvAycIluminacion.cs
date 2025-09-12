using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class EvAycIluminacion
    {
        public int Transid { get; set; }
        public int Idtarea { get; set; }
        public string Fuente { get; set; }
        public string Intensidad { get; set; }
        public string Observaciones { get; set; }
        public Guid? Idsync { get; set; }

        public virtual Tarea IdtareaNavigation { get; set; }
    }
}
