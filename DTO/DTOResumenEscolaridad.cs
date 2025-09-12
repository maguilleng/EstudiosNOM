using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOResumenEscolaridad
    {
        public int CantidadSinFormacion { get; set; }
        public double PorcentajeSinFormacion { set; get; }

        public int CantidadPrimaria { get; set; }
        public double PorcentajePrimaria { set; get; }

        public int CantidadSecundaria { get; set; }
        public double PorcentajeSecundaria { set; get; }

        public int CantidadPreparatoria { get; set; }
        public double PorcentajePreparatoria { set; get; }

        public int CantidadTecnicoSuperior { get; set; }
        public double PorcentajeTecnicoSuperior { set; get; }

        public int CantidadLicenciatura { get; set; }
        public double PorcentajeLicenciatura { set; get; }

        public int CantidadMaestria { get; set; }
        public double PorcentajeMaestria { set; get; }

        public int CantidadDoctorado { get; set; }
        public double PorcentajeDoctorado { set; get; }
    }
}
