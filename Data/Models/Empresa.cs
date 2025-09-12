using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            EstudioRfcempresaEvaNavigations = new HashSet<Estudio>();
            EstudioRfcempresaNavigations = new HashSet<Estudio>();
        }

        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public bool Evaluadora { get; set; }
        public string Giro { get; set; }
        public string DireccionFiscal { get; set; }
        public string RepresentanteLegal { get; set; }
        public string ResponsableInforme { get; set; }
        public string InstalacionOficinaBase { get; set; }
        public int? CapacidadInstalada { get; set; }
        public string Proceso { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public Guid? Idsync { get; set; }

        public virtual ICollection<Estudio> EstudioRfcempresaEvaNavigations { get; set; }
        public virtual ICollection<Estudio> EstudioRfcempresaNavigations { get; set; }
    }
}
