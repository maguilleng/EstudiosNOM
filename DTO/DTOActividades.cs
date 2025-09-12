using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOActividades
    {
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


    }
}
