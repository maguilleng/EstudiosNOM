using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOReporteNom35GuiaII
    {
        public DTOEstudios Estudio { get; set; } // regresar todo el estudio 
        public DTOEmpresas EmpresaEvaluada { get; set; } // regresar todo la empresa 
        public DTOEmpresas EmpresaEvaluadora { get; set; } // regresar todo la empresa (aún no)
        public List<DTOTrabajadoresEvaluados> Evaluaciones { get; set; }  // regresar todos los datos de todos los trabajadores

        //Estadísticas generales -- 1SP
        public int CantidadFemeninos { get; set; } //suma de quienes caen en ese rango
        public double PorcentajeFemeninos { get; set; }
        public int CantidadMasculinos { get; set; } //suma de quienes caen en ese rango
        public double PorcentajeMasculinos { get; set; }
        public DTORangosEdad RangosEdad { get; set; } //suma de quienes caen en ese rango  
        public DTOAntiguedadPuesto AntiguedadPuesto { get; set; } //suma de quienes caen en ese rango
        public DTOResumenJornadaLaboral ResumenJornadaLaboral { get; set; } //suma de quienes caen en ese rango
        public DTOResumenEscolaridad ResumenEscolaridad { get; set; } //suma de quienes caen en ese rango
        public DTOAcontecimientosTraumaticos CatAcontecimientosTraumaticosData { get; set; }

        //Datos Categorías Guia II -- 1SP
        public DTONom35CategoryDomain CatAmbienteTrabajoData { get; set; }
        public DTONom35CategoryDomain CatFactoresPropiosActividadData { get; set; }
        public DTONom35CategoryDomain CatOrgTiempoTrabajo { get; set; }
        public DTONom35CategoryDomain CatLiderazgoRelacionesData { get; set; }
        public DTONom35CategoryDomain CatEntornoOrganizacionalData { get; set; }

        //Datos Dominios Guia II
        public DTONom35CategoryDomain DomCondicionesAmbTrabajoData { get; set; }
        public DTONom35CategoryDomain DomCargaTrabajoData { get; set; }
        public DTONom35CategoryDomain DomFaltaControlTrabajoData { get; set; }
        public DTONom35CategoryDomain DomJornadaTrabajoData { get; set; }
        public DTONom35CategoryDomain DomInterferenciaTrabajoFamiliaData { get; set; }
        public DTONom35CategoryDomain DomLiderazgoData { get; set; }
        public DTONom35CategoryDomain DomRelacionesTrabajoData { get; set; }
        public DTONom35CategoryDomain DomViolenciaData { get; set; }
        public DTONom35CategoryDomain DomReconocimientoDesempeñoData { get; set; }
        public DTONom35CategoryDomain DomInsuficientePerteneciaEInestabilidadData { get; set; }

        //Datos cuestionario GuiaII
        public DTONom35CategoryDomain CatCalificacionFinalData { get; set; }

        //Datos Categorías Guia III
    }
}
