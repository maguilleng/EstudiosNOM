using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Link
    {
        public int Idlink { get; set; }
        public int? Idestudio { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? TipoLink { get; set; }
        public Guid? Link1 { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? Vigencia { get; set; }
        public bool? Estatus { get; set; }

        public virtual Estudio IdestudioNavigation { get; set; }
    }
}
