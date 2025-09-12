using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEVMuscoloesqueleticos
    {
        public int Transid { get; set; }
        public int Idempleado { get; set; }
        public int Idregion { get; set; }
        public bool Molestias { get; set; }
        public bool Izquierdo { get; set; }
        public bool Derecho { get; set; }
        public string Duracion { get; set; }
        public bool CambioPuesto { get; set; }
        public bool Ult12M { get; set; }
        public string Tiempo { get; set; }
        public string DuracionEpisodio { get; set; }
        public string ImpedimentoTrabajo { get; set; }
        public bool TratamientoMedico { get; set; }
        public bool Ult7Dias { get; set; }
        public int Calificacion { get; set; }
        public string Factores { get; set; }
        public Guid? Idsync { get; set; }
    }
}
