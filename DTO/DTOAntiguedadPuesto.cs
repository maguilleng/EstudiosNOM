using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAntiguedadPuesto
    {
        public int Cantidad6Meses { get; set; }
        public double Porcentaje6Meses { set; get; }

        public int Cantidad_6M_1A { get; set; }
        public double Porcentaje_6M_1A { set; get; }

        public int Cantidad_1A_4A { get; set; }
        public double Porcentaje_1A_4A { set; get; }

        public int Cantidad_5A_9A { get; set; }
        public double Porcentaje_5A_9A { set; get; }

        public int Cantidad_10A_14A { get; set; }
        public double Porcentaje_10A_14A { set; get; }

        public int Cantidad_15A_19A { get; set; }
        public double Porcentaje_15A_19A { set; get; }

        public int Cantidad_20A_24A { get; set; }
        public double Porcentaje_20A_24A { set; get; }

        public int Cantidad_Mas25A { get; set; }
        public double Porcentaje_Mas25A { set; get; }
    }
}
