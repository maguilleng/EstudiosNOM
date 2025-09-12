using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAcontecimientosTraumaticos
    {
        public int CantidadRequiereAtencionClinica { get; set; }
        public double PorcentajeRequiereAtencionClinica { set; get; }

        public int CantidadNoRequiereAtencionClinica { get; set; }
        public double PorcentajeNoRequiereAtencionClinica { set; get; }
    }
}
