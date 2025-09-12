using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Graficas_GUIAII
    {
        public string concepto { get; set; }
        public int Nulo { get; set; }
        public int Bajo { get; set; }
        public int Medio { get; set; }
        public int Alto { get; set; }
        public int MuyAlto { get; set; }

        public decimal PNulo { get; set; }
        public decimal PBajo { get; set; }
        public decimal PMedio { get; set; }
        public decimal PAlto { get; set; }
        public decimal PMuyAlto { get; set; }
    }
}
