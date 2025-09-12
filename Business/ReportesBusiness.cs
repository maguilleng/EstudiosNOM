using Contract.Business;
using Data.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReportesBusiness : IReportesBusiness
    {
        DTOReporteNom35GuiaII reporteGuiaII = new DTOReporteNom35GuiaII();
        ESTUDIOS_NOM35Context contexto = new ESTUDIOS_NOM35Context();
        ApiResponse<DTOReporteNom35GuiaII> response = new ApiResponse<DTOReporteNom35GuiaII>();

        public ApiResponse<DTOReporteNom35GuiaII> GetReporteGuiaII(int idEstudio)
        {
            try
            {
                var estudios = contexto.Estudios.Include(p => p.TrabajadoresEstudios).Include(p => p.RfcempresaEvaNavigation).Include(p => p.RfcempresaNavigation).ToList().Where(p => p.Idestudio == idEstudio);
                var estudio = estudios.FirstOrDefault();

                DTOEstudios dtEstudios = new DTOEstudios();
                dtEstudios.Activo = estudio.Activo;
                dtEstudios.FechaCaptura = estudio.FechaCaptura;
                dtEstudios.FechaInforme = estudio.FechaInforme;
                dtEstudios.GuiaIi = estudio.GuiaIi;
                dtEstudios.GuiaIii = estudio.GuiaIii;
                dtEstudios.Idestudio = estudio.Idestudio;
                dtEstudios.Instalacion = estudio.Instalacion;
                dtEstudios.Rfcempresa = estudio.Rfcempresa;
                dtEstudios.RfcempresaEva = estudio.RfcempresaEva;
                dtEstudios.Subtitulo = estudio.Subtitulo;
                dtEstudios.Titulo = estudio.Titulo;

                DTOEmpresas dtEmpresa = new DTOEmpresas();
                dtEmpresa.Activo = estudio.RfcempresaNavigation.Activo;
                dtEmpresa.CapacidadInstalada = estudio.RfcempresaNavigation.CapacidadInstalada;
                dtEmpresa.DireccionFiscal = estudio.RfcempresaNavigation.DireccionFiscal;
                dtEmpresa.Email = estudio.RfcempresaNavigation.Email;
                dtEmpresa.Evaluadora = estudio.RfcempresaNavigation.Evaluadora;
                dtEmpresa.Giro = estudio.RfcempresaNavigation.Giro;
                dtEmpresa.InstalacionOficinaBase = estudio.RfcempresaNavigation.InstalacionOficinaBase;
                dtEmpresa.Proceso = estudio.RfcempresaNavigation.Proceso;
                dtEmpresa.RazonSocial = estudio.RfcempresaNavigation.RazonSocial;
                dtEmpresa.RepresentanteLegal = estudio.RfcempresaNavigation.RepresentanteLegal;
                dtEmpresa.ResponsableInforme = estudio.RfcempresaNavigation.ResponsableInforme;
                dtEmpresa.Rfc = estudio.RfcempresaNavigation.Rfc;

                DTOEmpresas dtEmpresaEv = new DTOEmpresas();
                dtEmpresaEv.Activo = estudio.RfcempresaEvaNavigation.Activo;
                dtEmpresaEv.CapacidadInstalada = estudio.RfcempresaEvaNavigation.CapacidadInstalada;
                dtEmpresaEv.DireccionFiscal = estudio.RfcempresaEvaNavigation.DireccionFiscal;
                dtEmpresaEv.Email = estudio.RfcempresaEvaNavigation.Email;
                dtEmpresaEv.Evaluadora = estudio.RfcempresaEvaNavigation.Evaluadora;
                dtEmpresaEv.Giro = estudio.RfcempresaEvaNavigation.Giro;
                dtEmpresaEv.InstalacionOficinaBase = estudio.RfcempresaEvaNavigation.InstalacionOficinaBase;
                dtEmpresaEv.Proceso = estudio.RfcempresaEvaNavigation.Proceso;
                dtEmpresaEv.RazonSocial = estudio.RfcempresaEvaNavigation.RazonSocial;
                dtEmpresaEv.RepresentanteLegal = estudio.RfcempresaEvaNavigation.RepresentanteLegal;
                dtEmpresaEv.ResponsableInforme = estudio.RfcempresaEvaNavigation.ResponsableInforme;
                dtEmpresaEv.Rfc = estudio.RfcempresaEvaNavigation.Rfc;

                List<DTOTrabajadoresEvaluados> dtEvaluaciones = new List<DTOTrabajadoresEvaluados>();

                foreach (var evaluaciones in estudio.TrabajadoresEstudios)
                {
                    DTOTrabajadoresEvaluados dtevaluacion = new DTOTrabajadoresEvaluados();
                    dtevaluacion.Activo = evaluaciones.Activo;
                    dtevaluacion.AntiguedadCategoria = evaluaciones.AntiguedadCategoria;
                    dtevaluacion.AntiguedadPuesto = evaluaciones.AntiguedadPuesto;
                    dtevaluacion.AreaFisica = evaluaciones.AreaFisica;
                    dtevaluacion.DepartamentoArea = evaluaciones.DepartamentoArea;
                    dtevaluacion.DescripcionPuesto = evaluaciones.DescripcionPuesto;
                    dtevaluacion.Edad = evaluaciones.Edad;
                    dtevaluacion.EstadoCivil = evaluaciones.EstadoCivil;
                    dtevaluacion.Evaluador = evaluaciones.Evaluador;
                    dtevaluacion.ExperienciaLaboral = evaluaciones.ExperienciaLaboral;
                    dtevaluacion.FechaEvaluacion = evaluaciones.FechaEvaluacion;
                    dtevaluacion.Horario = evaluaciones.Horario;
                    dtevaluacion.Idestudio = evaluaciones.Idestudio;
                    dtevaluacion.Idtrabajador = evaluaciones.Idtrabajador;
                    dtevaluacion.InstalacionOficinaTaller = evaluaciones.InstalacionOficinaTaller;
                    dtevaluacion.JornadaTrabajo = evaluaciones.JornadaTrabajo;
                    dtevaluacion.NivelEstudio = evaluaciones.NivelEstudio;
                    dtevaluacion.Nombre = evaluaciones.Nombre;
                    dtevaluacion.PuestoCategoria = evaluaciones.PuestoCategoria;
                    dtevaluacion.RotaTurnos = evaluaciones.RotaTurnos;
                    dtevaluacion.Sexo = evaluaciones.Sexo;
                    dtevaluacion.TipoContratacion = evaluaciones.TipoContratacion;
                    dtevaluacion.TipoJornada = evaluaciones.TipoJornada;
                    dtevaluacion.TipoPersonal = evaluaciones.TipoPersonal;
                    dtevaluacion.TipoPuesto = evaluaciones.TipoPuesto;
                    dtEvaluaciones.Add(dtevaluacion);
                }
                reporteGuiaII.Estudio = dtEstudios;
                reporteGuiaII.EmpresaEvaluada = dtEmpresa;
                reporteGuiaII.EmpresaEvaluadora = dtEmpresaEv;
                reporteGuiaII.Evaluaciones = dtEvaluaciones;

                /*GRAFICAS GUIA III*/
                var rango = contexto.GrafciasGuiaII.FromSqlRaw("exec SP_GraficasGuiaII '" + idEstudio + "'").ToList();

                var CargaTrabajo = rango.Find(p => p.concepto == "Carga de trabajo");
                DTONom35CategoryDomain dtCargaTrabajo = new DTONom35CategoryDomain();
                dtCargaTrabajo.NuloValue = CargaTrabajo.Nulo;
                dtCargaTrabajo.NuloPorcentaje = (double)CargaTrabajo.PNulo;
                dtCargaTrabajo.BajoValue = CargaTrabajo.Bajo;
                dtCargaTrabajo.BajoPorcentaje = (double)CargaTrabajo.PBajo;
                dtCargaTrabajo.MedioValue = CargaTrabajo.Medio;
                dtCargaTrabajo.MedioPorcentaje = (double)CargaTrabajo.PMedio;
                dtCargaTrabajo.AltoValue = CargaTrabajo.Alto;
                dtCargaTrabajo.AltoPorcentaje = (double)CargaTrabajo.PAlto;
                dtCargaTrabajo.MuyAltoValue = CargaTrabajo.MuyAlto;
                dtCargaTrabajo.MuyAltoPorcentaje = (double)CargaTrabajo.PMuyAlto;
                reporteGuiaII.DomCargaTrabajoData = dtCargaTrabajo;

                var CondicionAmbientedetrabajo = rango.Find(p => p.concepto == "Condiciones en el ambiente de trabajo");
                DTONom35CategoryDomain dtCondicionAmbientedetrabajo = new DTONom35CategoryDomain();
                dtCondicionAmbientedetrabajo.NuloValue = CondicionAmbientedetrabajo.Nulo;
                dtCondicionAmbientedetrabajo.NuloPorcentaje = (double)CondicionAmbientedetrabajo.PNulo;
                dtCondicionAmbientedetrabajo.BajoValue = CondicionAmbientedetrabajo.Bajo;
                dtCondicionAmbientedetrabajo.BajoPorcentaje = (double)CondicionAmbientedetrabajo.PBajo;
                dtCondicionAmbientedetrabajo.MedioValue = CondicionAmbientedetrabajo.Medio;
                dtCondicionAmbientedetrabajo.MedioPorcentaje = (double)CondicionAmbientedetrabajo.PMedio;
                dtCondicionAmbientedetrabajo.AltoValue = CondicionAmbientedetrabajo.Alto;
                dtCondicionAmbientedetrabajo.AltoPorcentaje = (double)CondicionAmbientedetrabajo.PAlto;
                dtCondicionAmbientedetrabajo.MuyAltoValue = CondicionAmbientedetrabajo.MuyAlto;
                dtCondicionAmbientedetrabajo.MuyAltoPorcentaje = (double)CondicionAmbientedetrabajo.PMuyAlto;
                reporteGuiaII.DomCondicionesAmbTrabajoData = dtCondicionAmbientedetrabajo;

                var FaltaControlSobreelTrabajo = rango.Find(p => p.concepto == "Falta de control sobre el trabajo");
                DTONom35CategoryDomain dtFaltaControlSobreelTrabajo = new DTONom35CategoryDomain();
                dtFaltaControlSobreelTrabajo.NuloValue = FaltaControlSobreelTrabajo.Nulo;
                dtFaltaControlSobreelTrabajo.NuloPorcentaje = (double)FaltaControlSobreelTrabajo.PNulo;
                dtFaltaControlSobreelTrabajo.BajoValue = FaltaControlSobreelTrabajo.Bajo;
                dtFaltaControlSobreelTrabajo.BajoPorcentaje = (double)FaltaControlSobreelTrabajo.PBajo;
                dtFaltaControlSobreelTrabajo.MedioValue = FaltaControlSobreelTrabajo.Medio;
                dtFaltaControlSobreelTrabajo.MedioPorcentaje = (double)FaltaControlSobreelTrabajo.PMedio;
                dtFaltaControlSobreelTrabajo.AltoValue = FaltaControlSobreelTrabajo.Alto;
                dtFaltaControlSobreelTrabajo.AltoPorcentaje = (double)FaltaControlSobreelTrabajo.PAlto;
                dtFaltaControlSobreelTrabajo.MuyAltoValue = FaltaControlSobreelTrabajo.MuyAlto;
                dtFaltaControlSobreelTrabajo.MuyAltoPorcentaje = (double)FaltaControlSobreelTrabajo.PMuyAlto;
                reporteGuiaII.DomFaltaControlTrabajoData = dtFaltaControlSobreelTrabajo;

                var InterferecniaRelacionTabajoFamilia = rango.Find(p => p.concepto == "Interferencia en la relación trabajo-familia");
                DTONom35CategoryDomain dtInterferecniaRelacionTabajoFamilia = new DTONom35CategoryDomain();
                dtInterferecniaRelacionTabajoFamilia.NuloValue = InterferecniaRelacionTabajoFamilia.Nulo;
                dtInterferecniaRelacionTabajoFamilia.NuloPorcentaje = (double)InterferecniaRelacionTabajoFamilia.PNulo;
                dtInterferecniaRelacionTabajoFamilia.BajoValue = InterferecniaRelacionTabajoFamilia.Bajo;
                dtInterferecniaRelacionTabajoFamilia.BajoPorcentaje = (double)InterferecniaRelacionTabajoFamilia.PBajo;
                dtInterferecniaRelacionTabajoFamilia.MedioValue = InterferecniaRelacionTabajoFamilia.Medio;
                dtInterferecniaRelacionTabajoFamilia.MedioPorcentaje = (double)InterferecniaRelacionTabajoFamilia.PMedio;
                dtInterferecniaRelacionTabajoFamilia.AltoValue = InterferecniaRelacionTabajoFamilia.Alto;
                dtInterferecniaRelacionTabajoFamilia.AltoPorcentaje = (double)InterferecniaRelacionTabajoFamilia.PAlto;
                dtInterferecniaRelacionTabajoFamilia.MuyAltoValue = InterferecniaRelacionTabajoFamilia.MuyAlto;
                dtInterferecniaRelacionTabajoFamilia.MuyAltoPorcentaje = (double)InterferecniaRelacionTabajoFamilia.PMuyAlto;
                reporteGuiaII.DomInterferenciaTrabajoFamiliaData = dtInterferecniaRelacionTabajoFamilia;

                var JornadaTrabajo = rango.Find(p => p.concepto == "Jornada de trabajo");
                DTONom35CategoryDomain dtJornadaTrabajo = new DTONom35CategoryDomain();
                dtJornadaTrabajo.NuloValue = JornadaTrabajo.Nulo;
                dtJornadaTrabajo.NuloPorcentaje = (double)JornadaTrabajo.PNulo;
                dtJornadaTrabajo.BajoValue = JornadaTrabajo.Bajo;
                dtJornadaTrabajo.BajoPorcentaje = (double)JornadaTrabajo.PBajo;
                dtJornadaTrabajo.MedioValue = JornadaTrabajo.Medio;
                dtJornadaTrabajo.MedioPorcentaje = (double)JornadaTrabajo.PMedio;
                dtJornadaTrabajo.AltoValue = JornadaTrabajo.Alto;
                dtJornadaTrabajo.AltoPorcentaje = (double)JornadaTrabajo.PAlto;
                dtJornadaTrabajo.MuyAltoValue = JornadaTrabajo.MuyAlto;
                dtJornadaTrabajo.MuyAltoPorcentaje = (double)JornadaTrabajo.PMuyAlto;
                reporteGuiaII.DomJornadaTrabajoData = dtJornadaTrabajo;

                var Liderazgo = rango.Find(p => p.concepto == "Liderazgo");
                DTONom35CategoryDomain dtLiderazgo = new DTONom35CategoryDomain();
                dtLiderazgo.NuloValue = Liderazgo.Nulo;
                dtLiderazgo.NuloPorcentaje = (double)Liderazgo.PNulo;
                dtLiderazgo.BajoValue = Liderazgo.Bajo;
                dtLiderazgo.BajoPorcentaje = (double)Liderazgo.PBajo;
                dtLiderazgo.MedioValue = Liderazgo.Medio;
                dtLiderazgo.MedioPorcentaje = (double)Liderazgo.PMedio;
                dtLiderazgo.AltoValue = Liderazgo.Alto;
                dtLiderazgo.AltoPorcentaje = (double)Liderazgo.PAlto;
                dtLiderazgo.MuyAltoValue = Liderazgo.MuyAlto;
                dtLiderazgo.MuyAltoPorcentaje = (double)Liderazgo.PMuyAlto;
                reporteGuiaII.DomLiderazgoData = dtLiderazgo;

                var RelacionesTrabajo = rango.Find(p => p.concepto == "Relaciones en el trabajo");
                DTONom35CategoryDomain dtRelacionesTrabajo = new DTONom35CategoryDomain();
                dtRelacionesTrabajo.NuloValue = RelacionesTrabajo.Nulo;
                dtRelacionesTrabajo.NuloPorcentaje = (double)RelacionesTrabajo.PNulo;
                dtRelacionesTrabajo.BajoValue = RelacionesTrabajo.Bajo;
                dtRelacionesTrabajo.BajoPorcentaje = (double)RelacionesTrabajo.PBajo;
                dtRelacionesTrabajo.MedioValue = RelacionesTrabajo.Medio;
                dtRelacionesTrabajo.MedioPorcentaje = (double)RelacionesTrabajo.PMedio;
                dtRelacionesTrabajo.AltoValue = RelacionesTrabajo.Alto;
                dtRelacionesTrabajo.AltoPorcentaje = (double)RelacionesTrabajo.PAlto;
                dtRelacionesTrabajo.MuyAltoValue = RelacionesTrabajo.MuyAlto;
                dtRelacionesTrabajo.MuyAltoPorcentaje = (double)RelacionesTrabajo.PMuyAlto;
                reporteGuiaII.DomRelacionesTrabajoData = dtRelacionesTrabajo;

                var Violencia = rango.Find(p => p.concepto == "Violencia");
                DTONom35CategoryDomain dtViolencia = new DTONom35CategoryDomain();
                dtViolencia.NuloValue = Violencia.Nulo;
                dtViolencia.NuloPorcentaje = (double)Violencia.PNulo;
                dtViolencia.BajoValue = Violencia.Bajo;
                dtViolencia.BajoPorcentaje = (double)Violencia.PBajo;
                dtViolencia.MedioValue = Violencia.Medio;
                dtViolencia.MedioPorcentaje = (double)Violencia.PMedio;
                dtViolencia.AltoValue = Violencia.Alto;
                dtViolencia.AltoPorcentaje = (double)Violencia.PAlto;
                dtViolencia.MuyAltoValue = Violencia.MuyAlto;
                dtViolencia.MuyAltoPorcentaje = (double)Violencia.PMuyAlto;
                reporteGuiaII.DomViolenciaData = dtViolencia;

                var infPertenenciaEInestibilidad = rango.Find(p => p.concepto == "Insuficiente sentido de pertenencia e inestabilidad");
                if (infPertenenciaEInestibilidad != null)
                {
                    DTONom35CategoryDomain dtinfPertenenciaEInestibilidad = new DTONom35CategoryDomain();
                    dtinfPertenenciaEInestibilidad.NuloValue = infPertenenciaEInestibilidad.Nulo;
                    dtinfPertenenciaEInestibilidad.NuloPorcentaje = (double)infPertenenciaEInestibilidad.PNulo;
                    dtinfPertenenciaEInestibilidad.BajoValue = infPertenenciaEInestibilidad.Bajo;
                    dtinfPertenenciaEInestibilidad.BajoPorcentaje = (double)infPertenenciaEInestibilidad.PBajo;
                    dtinfPertenenciaEInestibilidad.MedioValue = infPertenenciaEInestibilidad.Medio;
                    dtinfPertenenciaEInestibilidad.MedioPorcentaje = (double)infPertenenciaEInestibilidad.PMedio;
                    dtinfPertenenciaEInestibilidad.AltoValue = infPertenenciaEInestibilidad.Alto;
                    dtinfPertenenciaEInestibilidad.AltoPorcentaje = (double)infPertenenciaEInestibilidad.PAlto;
                    dtinfPertenenciaEInestibilidad.MuyAltoValue = infPertenenciaEInestibilidad.MuyAlto;
                    dtinfPertenenciaEInestibilidad.MuyAltoPorcentaje = (double)infPertenenciaEInestibilidad.PMuyAlto;
                    reporteGuiaII.DomInsuficientePerteneciaEInestabilidadData = dtinfPertenenciaEInestibilidad;
                }

                var reconocimientoDesempeño = rango.Find(p => p.concepto == "Reconocimiento del desempeño");
                if (reconocimientoDesempeño != null)
                {
                    DTONom35CategoryDomain dtreconocimientoDesempeño = new DTONom35CategoryDomain();
                    dtreconocimientoDesempeño.NuloValue = reconocimientoDesempeño.Nulo;
                    dtreconocimientoDesempeño.NuloPorcentaje = (double)reconocimientoDesempeño.PNulo;
                    dtreconocimientoDesempeño.BajoValue = reconocimientoDesempeño.Bajo;
                    dtreconocimientoDesempeño.BajoPorcentaje = (double)reconocimientoDesempeño.PBajo;
                    dtreconocimientoDesempeño.MedioValue = reconocimientoDesempeño.Medio;
                    dtreconocimientoDesempeño.MedioPorcentaje = (double)reconocimientoDesempeño.PMedio;
                    dtreconocimientoDesempeño.AltoValue = reconocimientoDesempeño.Alto;
                    dtreconocimientoDesempeño.AltoPorcentaje = (double)reconocimientoDesempeño.PAlto;
                    dtreconocimientoDesempeño.MuyAltoValue = reconocimientoDesempeño.MuyAlto;
                    dtreconocimientoDesempeño.MuyAltoPorcentaje = (double)reconocimientoDesempeño.PMuyAlto;
                    reporteGuiaII.DomReconocimientoDesempeñoData = dtreconocimientoDesempeño;
                }

                var AmbienteTrabajo = rango.Find(p => p.concepto == "Ambiente de trabajo");
                DTONom35CategoryDomain dtAmbienteTrabajo = new DTONom35CategoryDomain();
                dtAmbienteTrabajo.NuloValue = AmbienteTrabajo.Nulo;
                dtAmbienteTrabajo.NuloPorcentaje = (double)AmbienteTrabajo.PNulo;
                dtAmbienteTrabajo.BajoValue = AmbienteTrabajo.Bajo;
                dtAmbienteTrabajo.BajoPorcentaje = (double)AmbienteTrabajo.PBajo;
                dtAmbienteTrabajo.MedioValue = AmbienteTrabajo.Medio;
                dtAmbienteTrabajo.MedioPorcentaje = (double)AmbienteTrabajo.PMedio;
                dtAmbienteTrabajo.AltoValue = AmbienteTrabajo.Alto;
                dtAmbienteTrabajo.AltoPorcentaje = (double)AmbienteTrabajo.PAlto;
                dtAmbienteTrabajo.MuyAltoValue = AmbienteTrabajo.MuyAlto;
                dtAmbienteTrabajo.MuyAltoPorcentaje = (double)AmbienteTrabajo.PMuyAlto;
                reporteGuiaII.CatAmbienteTrabajoData = dtAmbienteTrabajo;

                var FactoresPropiosActividad = rango.Find(p => p.concepto == "Factores propios de la actividad");
                DTONom35CategoryDomain dtFactoresPropiosActividad = new DTONom35CategoryDomain();
                dtFactoresPropiosActividad.NuloValue = FactoresPropiosActividad.Nulo;
                dtFactoresPropiosActividad.NuloPorcentaje = (double)FactoresPropiosActividad.PNulo;
                dtFactoresPropiosActividad.BajoValue = FactoresPropiosActividad.Bajo;
                dtFactoresPropiosActividad.BajoPorcentaje = (double)FactoresPropiosActividad.PBajo;
                dtFactoresPropiosActividad.MedioValue = FactoresPropiosActividad.Medio;
                dtFactoresPropiosActividad.MedioPorcentaje = (double)FactoresPropiosActividad.PMedio;
                dtFactoresPropiosActividad.AltoValue = FactoresPropiosActividad.Alto;
                dtFactoresPropiosActividad.AltoPorcentaje = (double)FactoresPropiosActividad.PAlto;
                dtFactoresPropiosActividad.MuyAltoValue = FactoresPropiosActividad.MuyAlto;
                dtFactoresPropiosActividad.MuyAltoPorcentaje = (double)FactoresPropiosActividad.PMuyAlto;
                reporteGuiaII.CatFactoresPropiosActividadData = dtFactoresPropiosActividad;


                var LiderazgoRelacionesTrabajo = rango.Find(p => p.concepto == "Liderazgo y relaciones en el trabajo");
                DTONom35CategoryDomain dtLiderazgoRelacionesTrabajo = new DTONom35CategoryDomain();
                dtLiderazgoRelacionesTrabajo.NuloValue = LiderazgoRelacionesTrabajo.Nulo;
                dtLiderazgoRelacionesTrabajo.NuloPorcentaje = (double)LiderazgoRelacionesTrabajo.PNulo;
                dtLiderazgoRelacionesTrabajo.BajoValue = LiderazgoRelacionesTrabajo.Bajo;
                dtLiderazgoRelacionesTrabajo.BajoPorcentaje = (double)LiderazgoRelacionesTrabajo.PBajo;
                dtLiderazgoRelacionesTrabajo.MedioValue = LiderazgoRelacionesTrabajo.Medio;
                dtLiderazgoRelacionesTrabajo.MedioPorcentaje = (double)LiderazgoRelacionesTrabajo.PMedio;
                dtLiderazgoRelacionesTrabajo.AltoValue = LiderazgoRelacionesTrabajo.Alto;
                dtLiderazgoRelacionesTrabajo.AltoPorcentaje = (double)LiderazgoRelacionesTrabajo.PAlto;
                dtLiderazgoRelacionesTrabajo.MuyAltoValue = LiderazgoRelacionesTrabajo.MuyAlto;
                dtLiderazgoRelacionesTrabajo.MuyAltoPorcentaje = (double)LiderazgoRelacionesTrabajo.PMuyAlto;
                reporteGuiaII.CatLiderazgoRelacionesData = dtLiderazgoRelacionesTrabajo;

                var OrganizacionTiempoTrabajo = rango.Find(p => p.concepto == "Organización del tiempo de trabajo");
                DTONom35CategoryDomain dtOrganizacionTiempoTrabajo = new DTONom35CategoryDomain();
                dtOrganizacionTiempoTrabajo.NuloValue = OrganizacionTiempoTrabajo.Nulo;
                dtOrganizacionTiempoTrabajo.NuloPorcentaje = (double)OrganizacionTiempoTrabajo.PNulo;
                dtOrganizacionTiempoTrabajo.BajoValue = OrganizacionTiempoTrabajo.Bajo;
                dtOrganizacionTiempoTrabajo.BajoPorcentaje = (double)OrganizacionTiempoTrabajo.PBajo;
                dtOrganizacionTiempoTrabajo.MedioValue = OrganizacionTiempoTrabajo.Medio;
                dtOrganizacionTiempoTrabajo.MedioPorcentaje = (double)OrganizacionTiempoTrabajo.PMedio;
                dtOrganizacionTiempoTrabajo.AltoValue = OrganizacionTiempoTrabajo.Alto;
                dtOrganizacionTiempoTrabajo.AltoPorcentaje = (double)OrganizacionTiempoTrabajo.PAlto;
                dtOrganizacionTiempoTrabajo.MuyAltoValue = OrganizacionTiempoTrabajo.MuyAlto;
                dtOrganizacionTiempoTrabajo.MuyAltoPorcentaje = (double)OrganizacionTiempoTrabajo.PMuyAlto;
                reporteGuiaII.CatOrgTiempoTrabajo = dtOrganizacionTiempoTrabajo;

                var EntornoOrganizacional = rango.Find(p => p.concepto == "Entorno Organizacional");
                if (EntornoOrganizacional != null)
                {
                    DTONom35CategoryDomain dtoEntornoOrganizacional = new DTONom35CategoryDomain();
                    dtoEntornoOrganizacional.NuloValue = EntornoOrganizacional.Nulo;
                    dtoEntornoOrganizacional.NuloPorcentaje = (double)EntornoOrganizacional.PNulo;
                    dtoEntornoOrganizacional.BajoValue = EntornoOrganizacional.Bajo;
                    dtoEntornoOrganizacional.BajoPorcentaje = (double)EntornoOrganizacional.PBajo;
                    dtoEntornoOrganizacional.MedioValue = EntornoOrganizacional.Medio;
                    dtoEntornoOrganizacional.MedioPorcentaje = (double)EntornoOrganizacional.PMedio;
                    dtoEntornoOrganizacional.AltoValue = EntornoOrganizacional.Alto;
                    dtoEntornoOrganizacional.AltoPorcentaje = (double)EntornoOrganizacional.PAlto;
                    dtoEntornoOrganizacional.MuyAltoValue = EntornoOrganizacional.MuyAlto;
                    dtoEntornoOrganizacional.MuyAltoPorcentaje = (double)EntornoOrganizacional.PMuyAlto;
                    reporteGuiaII.CatEntornoOrganizacionalData = dtoEntornoOrganizacional;
                }

                var CalificacionFinal = rango.Find(p => p.concepto == "Calificación final del cuestionario\r\n");
                DTONom35CategoryDomain dtCalificacionFinal = new DTONom35CategoryDomain();
                dtCalificacionFinal.NuloValue = CalificacionFinal.Nulo;
                dtCalificacionFinal.NuloPorcentaje = (double)CalificacionFinal.PNulo;
                dtCalificacionFinal.BajoValue = CalificacionFinal.Bajo;
                dtCalificacionFinal.BajoPorcentaje = (double)CalificacionFinal.PBajo;
                dtCalificacionFinal.MedioValue = CalificacionFinal.Medio;
                dtCalificacionFinal.MedioPorcentaje = (double)CalificacionFinal.PMedio;
                dtCalificacionFinal.AltoValue = CalificacionFinal.Alto;
                dtCalificacionFinal.AltoPorcentaje = (double)CalificacionFinal.PAlto;
                dtCalificacionFinal.MuyAltoValue = CalificacionFinal.MuyAlto;
                dtCalificacionFinal.MuyAltoPorcentaje = (double)CalificacionFinal.PMuyAlto;
                reporteGuiaII.CatCalificacionFinalData = dtCalificacionFinal;

                /*TOTALES GRAFICAS*/
                var totales = contexto.TotalesGraficas.FromSqlRaw("exec SP_TotalesGraficas '" + idEstudio + "'").ToList();

                var masculinos = totales.Find(p => p.Concepto.Equals("M"));
                var femeninos = totales.Find(p => p.Concepto.Equals("F"));

                int totalMasculinos = masculinos == null ? 0 : masculinos.Valor;
                int totalfemeninos = femeninos == null ? 0 : femeninos.Valor;
                int totalSexo = totalMasculinos + totalfemeninos;

                decimal pMasculino;
                reporteGuiaII.CantidadMasculinos = totalMasculinos;
                pMasculino = decimal.Round((decimal)totalMasculinos / totalSexo * 100, 2);
                reporteGuiaII.PorcentajeMasculinos = (double)pMasculino;

                decimal pFemenino;
                reporteGuiaII.CantidadFemeninos = totalfemeninos;
                pFemenino = decimal.Round((decimal)totalfemeninos / totalSexo * 100, 2);
                reporteGuiaII.PorcentajeFemeninos = (double)pFemenino;

                var atencionClinicaSI = totales.Find(p => p.Concepto.Equals("REQUIERE ATENCIÓN CLINICA"));
                var atencionClinicaNO = totales.Find(p => p.Concepto.Equals("NO REQUIERE ATENCIÓN CLINICA"));

                int totalSI = atencionClinicaSI == null ? 0 : atencionClinicaSI.Valor;
                int totalNO = atencionClinicaNO == null ? 0 : atencionClinicaNO.Valor;
                int TotalAtencion = totalSI + totalNO;
                DTOAcontecimientosTraumaticos dtAcontecimientosTraumaticos = new DTOAcontecimientosTraumaticos();

                decimal pSI;
                dtAcontecimientosTraumaticos.CantidadRequiereAtencionClinica = totalSI;
                pSI = decimal.Round((decimal)totalSI / TotalAtencion * 100, 2);
                dtAcontecimientosTraumaticos.PorcentajeRequiereAtencionClinica = (double)pSI;

                decimal pNO;
                dtAcontecimientosTraumaticos.CantidadNoRequiereAtencionClinica = totalNO;
                pNO = decimal.Round((decimal)totalNO / TotalAtencion * 100, 2);
                dtAcontecimientosTraumaticos.PorcentajeNoRequiereAtencionClinica = (double)pNO;
                reporteGuiaII.CatAcontecimientosTraumaticosData = dtAcontecimientosTraumaticos;

                var Edad1519 = totales.Find(p => p.Concepto.Equals("15-19"));
                var Edad2024 = totales.Find(p => p.Concepto.Equals("20-24"));
                var Edad2529 = totales.Find(p => p.Concepto.Equals("25-29"));
                var Edad3034 = totales.Find(p => p.Concepto.Equals("30-34"));
                var Edad3539 = totales.Find(p => p.Concepto.Equals("35-39"));
                var Edad4044 = totales.Find(p => p.Concepto.Equals("40-44"));
                var Edad4549 = totales.Find(p => p.Concepto.Equals("45-49"));
                var Edad5054 = totales.Find(p => p.Concepto.Equals("50-54"));
                var Edad5559 = totales.Find(p => p.Concepto.Equals("55-59"));
                var Edad6064 = totales.Find(p => p.Concepto.Equals("60-64"));
                var Edad6569 = totales.Find(p => p.Concepto.Equals("65-69"));
                var Edad70 = totales.Find(p => p.Concepto.Equals("70+"));

                int totalEdad1519 = Edad1519 == null ? 0 : Edad1519.Valor;
                int totalEdad2024 = Edad2024 == null ? 0 : Edad2024.Valor;
                int totalEdad2529 = Edad2529 == null ? 0 : Edad2529.Valor;
                int totalEdad3034 = Edad3034 == null ? 0 : Edad3034.Valor;
                int totalEdad3539 = Edad3539 == null ? 0 : Edad3539.Valor;
                int totalEdad4044 = Edad4044 == null ? 0 : Edad4044.Valor;
                int totalEdad4549 = Edad4549 == null ? 0 : Edad4549.Valor;
                int totalEdad5054 = Edad5054 == null ? 0 : Edad5054.Valor;
                int totalEdad5559 = Edad5559 == null ? 0 : Edad5559.Valor;
                int totalEdad6064 = Edad6064 == null ? 0 : Edad6064.Valor;
                int totalEdad6569 = Edad6569 == null ? 0 : Edad6569.Valor;
                int totalEdad70 = Edad70 == null ? 0 : Edad70.Valor;
                int totalEdades = totalEdad1519 + totalEdad2024 + totalEdad2529 + totalEdad3034 + totalEdad3539 + totalEdad4044 + totalEdad4549 + totalEdad5054 + totalEdad5559 + totalEdad6064 + totalEdad6569 + totalEdad70;
                DTORangosEdad dtRangosEdad = new DTORangosEdad();

                decimal pEdad1519;
                dtRangosEdad.CantidadPersonas15_19 = totalEdad1519;
                pEdad1519 = decimal.Round((decimal)totalEdad1519 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas15_19 = (double)pEdad1519;

                decimal pEdad2024;
                dtRangosEdad.CantidadPersonas20_24 = totalEdad2024;
                pEdad2024 = decimal.Round((decimal)totalEdad2024 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas20_24 = (double)pEdad2024;

                decimal pEdad2529;
                dtRangosEdad.CantidadPersonas25_29 = totalEdad2529;
                pEdad2529 = decimal.Round((decimal)totalEdad2529 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas25_29 = (double)pEdad2529;

                decimal pEdad3034;
                dtRangosEdad.CantidadPersonas30_34 = totalEdad3034;
                pEdad3034 = decimal.Round((decimal)totalEdad3034 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas30_34 = (double)pEdad3034;

                decimal pEdad3539;
                dtRangosEdad.CantidadPersonas35_39 = totalEdad3539;
                pEdad3539 = decimal.Round((decimal)totalEdad3539 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas35_39 = (double)pEdad3539;

                decimal pEdad4044;
                dtRangosEdad.CantidadPersonas40_44 = totalEdad4044;
                pEdad4044 = decimal.Round((decimal)totalEdad4044 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas40_44 = (double)pEdad4044;

                decimal pEdad4549;
                dtRangosEdad.CantidadPersonas45_49 = totalEdad4549;
                pEdad4549 = decimal.Round((decimal)totalEdad4549 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas45_49 = (double)pEdad4549;

                decimal pEdad5054;
                dtRangosEdad.CantidadPersonas50_54 = totalEdad5054;
                pEdad5054 = decimal.Round((decimal)totalEdad5054 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas50_54 = (double)pEdad5054;

                decimal pEdad5559;
                dtRangosEdad.CantidadPersonas55_59 = totalEdad5559;
                pEdad5559 = decimal.Round((decimal)totalEdad5559 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas55_59 = (double)pEdad5559;

                decimal pEdad6064;
                dtRangosEdad.CantidadPersonas60_64 = totalEdad6064;
                pEdad6064 = decimal.Round((decimal)totalEdad6064 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas60_64 = (double)pEdad6064;

                decimal pEdad6069;
                dtRangosEdad.CantidadPersonas65_69 = totalEdad6569;
                pEdad6069 = decimal.Round((decimal)totalEdad6569 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas65_69 = (double)pEdad6069;

                decimal pEdad70;
                dtRangosEdad.CantidadPersonas70Mas = totalEdad70;
                pEdad70 = decimal.Round((decimal)totalEdad70 / totalEdades * 100, 2);
                dtRangosEdad.PorcentajePersonas70Mas = (double)pEdad70;
                reporteGuiaII.RangosEdad = dtRangosEdad;

                //ANTIGUEDAD DE PUESTO
                var ap6M = totales.Find(p => p.Concepto.Equals("<6M"));
                var ap6M1A = totales.Find(p => p.Concepto.Equals("6M-1A"));
                var ap14A = totales.Find(p => p.Concepto.Equals("1-4A"));
                var ap59A = totales.Find(p => p.Concepto.Equals("5-9A"));
                var ap1014A = totales.Find(p => p.Concepto.Equals("10-14A"));
                var ap1519A = totales.Find(p => p.Concepto.Equals("15-19A"));
                var ap2024A = totales.Find(p => p.Concepto.Equals("20-24A"));
                var ap25A = totales.Find(p => p.Concepto.Equals(">25A"));


                int totalap6M = ap6M == null ? 0 : ap6M.Valor;
                int totalap6M1A = ap6M1A == null ? 0 : ap6M1A.Valor;
                int totalap14A = ap14A == null ? 0 : ap14A.Valor;
                int totalap59A = ap59A == null ? 0 : ap59A.Valor;
                int totalap1014A = ap1014A == null ? 0 : ap1014A.Valor;
                int totalap1519A = ap1519A == null ? 0 : ap1519A.Valor;
                int totalap2024A = ap2024A == null ? 0 : ap2024A.Valor;
                int totalap25A = ap25A == null ? 0 : ap25A.Valor;
                int totalAntiguedadPuesto = totalap6M + totalap6M1A + totalap14A + totalap59A + totalap1014A + totalap1519A + totalap2024A + totalap25A;
                DTOAntiguedadPuesto dtAntiguedadPuesto = new DTOAntiguedadPuesto();

                decimal pap6M;
                dtAntiguedadPuesto.Cantidad6Meses = totalap6M;
                pap6M = decimal.Round((decimal)totalap6M / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje6Meses = (double)pap6M;

                decimal pap6M1A;
                dtAntiguedadPuesto.Cantidad_6M_1A = totalap6M1A;
                pap6M1A = decimal.Round((decimal)totalap6M1A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_6M_1A = (double)pap6M1A;

                decimal pap14A;
                dtAntiguedadPuesto.Cantidad_1A_4A = totalap14A;
                pap14A = decimal.Round((decimal)totalap14A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_1A_4A = (double)pap14A;

                decimal pap59A;
                dtAntiguedadPuesto.Cantidad_5A_9A = totalap59A;
                pap59A = decimal.Round((decimal)totalap59A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_5A_9A = (double)pap59A;

                decimal pap1014A;
                dtAntiguedadPuesto.Cantidad_10A_14A = totalap1014A;
                pap1014A = decimal.Round((decimal)totalap1014A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_10A_14A = (double)pap1014A;

                decimal pap1519A;
                dtAntiguedadPuesto.Cantidad_15A_19A = totalap1519A;
                pap1519A = decimal.Round((decimal)totalap1519A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_15A_19A = (double)pap1519A;

                decimal pap2024A;
                dtAntiguedadPuesto.Cantidad_20A_24A = totalap2024A;
                pap2024A = decimal.Round((decimal)totalap2024A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_20A_24A = (double)pap2024A;

                decimal pap25A;
                dtAntiguedadPuesto.Cantidad_Mas25A = totalap25A;
                pap25A = decimal.Round((decimal)totalap25A / totalAntiguedadPuesto * 100, 2);
                dtAntiguedadPuesto.Porcentaje_Mas25A = (double)pap25A;
                reporteGuiaII.AntiguedadPuesto = dtAntiguedadPuesto;

                var Nocturno = totales.Find(p => p.Concepto.Equals("Nocturno"));
                var Diurno = totales.Find(p => p.Concepto.Equals("Diurno"));
                var Mixto = totales.Find(p => p.Concepto.Equals("Mixto"));

                int totalNocturno = Nocturno == null ? 0 : Nocturno.Valor;
                int totalDiurno = Diurno == null ? 0 : Diurno.Valor;
                int totalMixto = Mixto == null ? 0 : Mixto.Valor;
                int totalJornada = totalNocturno + totalDiurno + totalMixto;
                DTOResumenJornadaLaboral dtJornadaLaboral = new DTOResumenJornadaLaboral();

                decimal pNocturno;
                dtJornadaLaboral.CantidadNocturno = totalNocturno;
                pNocturno = decimal.Round((decimal)totalNocturno / totalJornada * 100, 2);
                dtJornadaLaboral.PorcentajeNocturno = (double)pNocturno;

                decimal pDiurno;
                dtJornadaLaboral.CantidadDiurno = totalDiurno;
                pDiurno = decimal.Round((decimal)totalDiurno / totalJornada * 100, 2);
                dtJornadaLaboral.PorcentajeDiurno = (double)pDiurno;

                decimal pMixtoA;
                dtJornadaLaboral.CantidadMixto = totalMixto;
                pMixtoA = decimal.Round((decimal)totalMixto / totalJornada * 100, 2);
                dtJornadaLaboral.PorcentajeMixto = (double)pMixtoA;
                reporteGuiaII.ResumenJornadaLaboral = dtJornadaLaboral;

                //Nivel Educativo
                var sinFormacion = totales.Find(p => p.Concepto.Equals("Sin formación"));
                var primaria = totales.Find(p => p.Concepto.Equals("Primaria"));
                var secundaria = totales.Find(p => p.Concepto.Equals("Secundaria"));
                var preparatoriaBachillerato = totales.Find(p => p.Concepto.Equals("Preparatoria o Bachillerato"));
                var tecnicoSuperior = totales.Find(p => p.Concepto.Equals("Técnico Superior"));
                var licenciatura = totales.Find(p => p.Concepto.Equals("Licenciatura"));
                var maestria = totales.Find(p => p.Concepto.Equals("Maestría"));
                var doctorado = totales.Find(p => p.Concepto.Equals("Doctorado"));


                int totalsinFormacion = sinFormacion == null ? 0 : sinFormacion.Valor;
                int totalprimaria = primaria == null ? 0 : primaria.Valor;
                int totalsecundaria = secundaria == null ? 0 : secundaria.Valor;
                int totalpreparatoriaBachillerato = preparatoriaBachillerato == null ? 0 : preparatoriaBachillerato.Valor;
                int totaltecnicoSuperior = tecnicoSuperior == null ? 0 : tecnicoSuperior.Valor;
                int totallicenciatura = licenciatura == null ? 0 : licenciatura.Valor;
                int totalmaestria = maestria == null ? 0 : maestria.Valor;
                int totaldoctorado = doctorado == null ? 0 : doctorado.Valor;
                int totalNivelesEstudios = totalsinFormacion + totalprimaria + totalsecundaria + totalpreparatoriaBachillerato + totaltecnicoSuperior + totallicenciatura + totalmaestria + totaldoctorado;
                DTOResumenEscolaridad dtResumenEscolaridad = new DTOResumenEscolaridad();

                decimal psinFormacion;
                dtResumenEscolaridad.CantidadSinFormacion = totalsinFormacion;
                psinFormacion = decimal.Round((decimal)totalsinFormacion / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeSinFormacion = (double)psinFormacion;

                decimal pprimaria;
                dtResumenEscolaridad.CantidadPrimaria = totalprimaria;
                pprimaria = decimal.Round((decimal)totalprimaria / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajePrimaria = (double)pprimaria;

                decimal psecundaria;
                dtResumenEscolaridad.CantidadSecundaria = totalsecundaria;
                psecundaria = decimal.Round((decimal)totalsecundaria / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeSecundaria = (double)psecundaria;

                decimal ppreparatoriaBachillerato;
                dtResumenEscolaridad.CantidadPreparatoria = totalpreparatoriaBachillerato;
                ppreparatoriaBachillerato = decimal.Round((decimal)totalpreparatoriaBachillerato / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajePreparatoria = (double)ppreparatoriaBachillerato;

                decimal ptecnicoSuperior;
                dtResumenEscolaridad.CantidadTecnicoSuperior = totaltecnicoSuperior;
                ptecnicoSuperior = decimal.Round((decimal)totaltecnicoSuperior / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeTecnicoSuperior = (double)ptecnicoSuperior;

                decimal plicenciatura;
                dtResumenEscolaridad.CantidadLicenciatura = totallicenciatura;
                plicenciatura = decimal.Round((decimal)totallicenciatura / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeLicenciatura = (double)plicenciatura;

                decimal pmaestria;
                dtResumenEscolaridad.CantidadMaestria = totalmaestria;
                pmaestria = decimal.Round((decimal)totalmaestria / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeMaestria = (double)pmaestria;

                decimal pdoctorado;
                dtResumenEscolaridad.CantidadDoctorado = totaldoctorado;
                pdoctorado = decimal.Round((decimal)totaldoctorado / totalNivelesEstudios * 100, 2);
                dtResumenEscolaridad.PorcentajeDoctorado = (double)pdoctorado;
                reporteGuiaII.ResumenEscolaridad = dtResumenEscolaridad;

                response.ResponseData = reporteGuiaII;
                response.IsSuccesfull = true;
                response.ErrorDetails = "Succesfull";
            }
            catch (Exception ex)
            {
                response.ResponseData = null;
                response.IsSuccesfull = false;
                response.ErrorDetails = ex.Message + " StackTrace: " + ex.StackTrace.ToString();
            }

            return response;
        }
    }
}
