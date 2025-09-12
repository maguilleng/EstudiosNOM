using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Actividade
    {
        public Actividade()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Idactividad { get; set; }
        public int? Idempleado { get; set; }
        public string Titulo { get; set; }
        public string Actividad { get; set; }
        public string Descripcion { get; set; }
        public string Materiales { get; set; }
        public string MaquinasEquipos { get; set; }
        public string Dotacion { get; set; }
        public string ProtecionPersonal { get; set; }
        public bool? Activo { get; set; }
        public Guid? Idsync { get; set; }

        public virtual TrabajadoresEstudio IdempleadoNavigation { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
