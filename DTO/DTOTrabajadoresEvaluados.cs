using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOTrabajadoresEvaluados
    {

        public int Idtrabajador { get; set; }
        public string Evaluador { get; set; }
        public DateTime? FechaEvaluacion { get; set; }
        public int Idestudio { get; set; }
        public Guid? Link { get; set; }
        public string? Nombre { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string NivelEstudio { get; set; }
        public string TipoContratacion { get; set; }
        public string TipoPersonal { get; set; }
        public string AntiguedadPuesto { get; set; }
        public string AntiguedadCategoria { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string TipoJornada { get; set; }
        public string JornadaTrabajo { get; set; }
        public bool? RotaTurnos { get; set; }
        public string? Horario { get; set; }
        public string PuestoCategoria { get; set; }
        public string DepartamentoArea { get; set; }
        public string InstalacionOficinaTaller { get; set; }
        public string AreaFisica { get; set; }
        public string TipoPuesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public bool? Activo { get; set; }
        public Guid? Idsync { get; set; }
        public string Region { get; set; }
        public string Ficha { get; set; }
        public int? NumHijos { get; set; }
        public string PuestosHaTenido { get; set; }
        public string RotacionGuardia { get; set; }
        public int? HorasExtraSemana { get; set; }
        public bool? TieneOtroTrabajo { get; set; }
        public int HorasExtraOtroTrabajo { get; set; }
    }
}
