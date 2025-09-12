using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class TrabajadoresEstudio
    {
        public TrabajadoresEstudio()
        {
            Actividades = new HashSet<Actividade>();
            EvEstadoNutricionals = new HashSet<EvEstadoNutricional>();
            EvMuscoloesqueleticos = new HashSet<EvMuscoloesqueletico>();
            NomResultados = new HashSet<NomResultado>();
        }

        public int Idtrabajador { get; set; }
        public string Evaluador { get; set; }
        public DateTime? FechaEvaluacion { get; set; }
        public int Idestudio { get; set; }
        public Guid? Link { get; set; }
        public string Nombre { get; set; }
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
        public string Horario { get; set; }
        public string PuestoCategoria { get; set; }
        public string DepartamentoArea { get; set; }
        public string InstalacionOficinaTaller { get; set; }
        public string AreaFisica { get; set; }
        public string TipoPuesto { get; set; }
        public string DescripcionPuesto { get; set; }
        public bool? Activo { get; set; }
        public Guid? Idsync { get; set; }

        public virtual Estudio IdestudioNavigation { get; set; }
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<EvEstadoNutricional> EvEstadoNutricionals { get; set; }
        public virtual ICollection<EvMuscoloesqueletico> EvMuscoloesqueleticos { get; set; }
        public virtual ICollection<NomResultado> NomResultados { get; set; }
    }
}
