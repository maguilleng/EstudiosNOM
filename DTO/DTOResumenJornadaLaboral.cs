using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOResumenJornadaLaboral
    {
        public int CantidadDiurno { get; set; }
        public double PorcentajeDiurno { set; get; }

        public int CantidadNocturno { get; set; }
        public double PorcentajeNocturno { set; get; }

        public int CantidadMixto { get; set; }
        public double PorcentajeMixto { set; get; }
    }
}
