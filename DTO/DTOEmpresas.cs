using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEmpresas
    {
        public int Idempresa { get; set; }
        public bool Evaluadora { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
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
    }
}
