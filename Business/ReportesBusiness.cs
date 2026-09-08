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
        private readonly ESTUDIOS_NOM35Context contexto;

        public ReportesBusiness(ESTUDIOS_NOM35Context context)
        {
            contexto = context;
        }

        public ApiResponse<DTOReporteNom35GuiaII> GetReporteGuiaII(int idEstudio)
        {
            var reporteGuiaII = new DTOReporteNom35GuiaII();
            var response = new ApiResponse<DTOReporteNom35GuiaII>();

            try
            {
                var estudio = contexto.Estudios
                    .Include(p => p.TrabajadoresEstudios)
                    .Include(p => p.RfcempresaEvaNavigation)
                    .Include(p => p.RfcempresaNavigation)
                    .FirstOrDefault(p => p.Idestudio == idEstudio);

                if (estudio == null)
                {
                    response.IsSuccesfull = false;
                    response.ErrorDetails = $"No se encontró el estudio con id {idEstudio}.";
                    return response;
                }

                if (estudio.RfcempresaNavigation == null || estudio.RfcempresaEvaNavigation == null)
                {
                    response.IsSuccesfull = false;
                    response.ErrorDetails = "El estudio no tiene empresa evaluada o evaluadora asociada.";
                    return response;
                }

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

                var rango = contexto.GrafciasGuiaII.FromSqlRaw("exec SP_GraficasGuiaII '" + idEstudio + "'").ToList();

                reporteGuiaII.DomCargaTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Carga de trabajo"));
                reporteGuiaII.DomCondicionesAmbTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Condiciones en el ambiente de trabajo"));
                reporteGuiaII.DomFaltaControlTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Falta de control sobre el trabajo"));
                reporteGuiaII.DomInterferenciaTrabajoFamiliaData = MapGraficaCategoria(FindGrafica(rango, "Interferencia en la relación trabajo-familia"));
                reporteGuiaII.DomJornadaTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Jornada de trabajo"));
                reporteGuiaII.DomLiderazgoData = MapGraficaCategoria(FindGrafica(rango, "Liderazgo"));
                reporteGuiaII.DomRelacionesTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Relaciones en el trabajo"));
                reporteGuiaII.DomViolenciaData = MapGraficaCategoria(FindGrafica(rango, "Violencia"));
                reporteGuiaII.DomInsuficientePerteneciaEInestabilidadData = MapGraficaCategoria(FindGrafica(rango, "Insuficiente sentido de pertenencia e inestabilidad"));
                reporteGuiaII.DomReconocimientoDesempeñoData = MapGraficaCategoria(FindGrafica(rango, "Reconocimiento del desempeño"));
                reporteGuiaII.CatAmbienteTrabajoData = MapGraficaCategoria(FindGrafica(rango, "Ambiente de trabajo"));
                reporteGuiaII.CatFactoresPropiosActividadData = MapGraficaCategoria(FindGrafica(rango, "Factores propios de la actividad"));
                reporteGuiaII.CatLiderazgoRelacionesData = MapGraficaCategoria(FindGrafica(rango, "Liderazgo y relaciones en el trabajo"));
                reporteGuiaII.CatOrgTiempoTrabajo = MapGraficaCategoria(FindGrafica(rango, "Organización del tiempo de trabajo"));
                reporteGuiaII.CatEntornoOrganizacionalData = MapGraficaCategoria(FindGrafica(rango, "Entorno Organizacional"));
                reporteGuiaII.CatCalificacionFinalData = MapGraficaCategoria(
                    FindGrafica(rango, "Calificación final del cuestionario")
                    ?? FindGraficaContains(rango, "Calificación final del cuestionario"));

                /*TOTALES GRAFICAS*/
                var totales = contexto.TotalesGraficas.FromSqlRaw("exec SP_TotalesGraficas '" + idEstudio + "'").ToList();

                var masculinos = totales.Find(p => p.Concepto.Equals("M"));
                var femeninos = totales.Find(p => p.Concepto.Equals("F"));

                int totalMasculinos = masculinos == null ? 0 : masculinos.Valor;
                int totalfemeninos = femeninos == null ? 0 : femeninos.Valor;
                int totalSexo = totalMasculinos + totalfemeninos;

                reporteGuiaII.CantidadMasculinos = totalMasculinos;
                reporteGuiaII.PorcentajeMasculinos = CalcularPorcentaje(totalMasculinos, totalSexo);

                reporteGuiaII.CantidadFemeninos = totalfemeninos;
                reporteGuiaII.PorcentajeFemeninos = CalcularPorcentaje(totalfemeninos, totalSexo);

                var atencionClinicaSI = totales.Find(p => p.Concepto.Equals("REQUIERE ATENCIÓN CLINICA"));
                var atencionClinicaNO = totales.Find(p => p.Concepto.Equals("NO REQUIERE ATENCIÓN CLINICA"));

                int totalSI = atencionClinicaSI == null ? 0 : atencionClinicaSI.Valor;
                int totalNO = atencionClinicaNO == null ? 0 : atencionClinicaNO.Valor;
                int TotalAtencion = totalSI + totalNO;
                DTOAcontecimientosTraumaticos dtAcontecimientosTraumaticos = new DTOAcontecimientosTraumaticos();

                dtAcontecimientosTraumaticos.CantidadRequiereAtencionClinica = totalSI;
                dtAcontecimientosTraumaticos.PorcentajeRequiereAtencionClinica = CalcularPorcentaje(totalSI, TotalAtencion);

                dtAcontecimientosTraumaticos.CantidadNoRequiereAtencionClinica = totalNO;
                dtAcontecimientosTraumaticos.PorcentajeNoRequiereAtencionClinica = CalcularPorcentaje(totalNO, TotalAtencion);
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

                dtRangosEdad.CantidadPersonas15_19 = totalEdad1519;
                dtRangosEdad.PorcentajePersonas15_19 = CalcularPorcentaje(totalEdad1519, totalEdades);

                dtRangosEdad.CantidadPersonas20_24 = totalEdad2024;
                dtRangosEdad.PorcentajePersonas20_24 = CalcularPorcentaje(totalEdad2024, totalEdades);

                dtRangosEdad.CantidadPersonas25_29 = totalEdad2529;
                dtRangosEdad.PorcentajePersonas25_29 = CalcularPorcentaje(totalEdad2529, totalEdades);

                dtRangosEdad.CantidadPersonas30_34 = totalEdad3034;
                dtRangosEdad.PorcentajePersonas30_34 = CalcularPorcentaje(totalEdad3034, totalEdades);

                dtRangosEdad.CantidadPersonas35_39 = totalEdad3539;
                dtRangosEdad.PorcentajePersonas35_39 = CalcularPorcentaje(totalEdad3539, totalEdades);

                dtRangosEdad.CantidadPersonas40_44 = totalEdad4044;
                dtRangosEdad.PorcentajePersonas40_44 = CalcularPorcentaje(totalEdad4044, totalEdades);

                dtRangosEdad.CantidadPersonas45_49 = totalEdad4549;
                dtRangosEdad.PorcentajePersonas45_49 = CalcularPorcentaje(totalEdad4549, totalEdades);

                dtRangosEdad.CantidadPersonas50_54 = totalEdad5054;
                dtRangosEdad.PorcentajePersonas50_54 = CalcularPorcentaje(totalEdad5054, totalEdades);

                dtRangosEdad.CantidadPersonas55_59 = totalEdad5559;
                dtRangosEdad.PorcentajePersonas55_59 = CalcularPorcentaje(totalEdad5559, totalEdades);

                dtRangosEdad.CantidadPersonas60_64 = totalEdad6064;
                dtRangosEdad.PorcentajePersonas60_64 = CalcularPorcentaje(totalEdad6064, totalEdades);

                dtRangosEdad.CantidadPersonas65_69 = totalEdad6569;
                dtRangosEdad.PorcentajePersonas65_69 = CalcularPorcentaje(totalEdad6569, totalEdades);

                dtRangosEdad.CantidadPersonas70Mas = totalEdad70;
                dtRangosEdad.PorcentajePersonas70Mas = CalcularPorcentaje(totalEdad70, totalEdades);
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

                dtAntiguedadPuesto.Cantidad6Meses = totalap6M;
                dtAntiguedadPuesto.Porcentaje6Meses = CalcularPorcentaje(totalap6M, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_6M_1A = totalap6M1A;
                dtAntiguedadPuesto.Porcentaje_6M_1A = CalcularPorcentaje(totalap6M1A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_1A_4A = totalap14A;
                dtAntiguedadPuesto.Porcentaje_1A_4A = CalcularPorcentaje(totalap14A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_5A_9A = totalap59A;
                dtAntiguedadPuesto.Porcentaje_5A_9A = CalcularPorcentaje(totalap59A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_10A_14A = totalap1014A;
                dtAntiguedadPuesto.Porcentaje_10A_14A = CalcularPorcentaje(totalap1014A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_15A_19A = totalap1519A;
                dtAntiguedadPuesto.Porcentaje_15A_19A = CalcularPorcentaje(totalap1519A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_20A_24A = totalap2024A;
                dtAntiguedadPuesto.Porcentaje_20A_24A = CalcularPorcentaje(totalap2024A, totalAntiguedadPuesto);

                dtAntiguedadPuesto.Cantidad_Mas25A = totalap25A;
                dtAntiguedadPuesto.Porcentaje_Mas25A = CalcularPorcentaje(totalap25A, totalAntiguedadPuesto);
                reporteGuiaII.AntiguedadPuesto = dtAntiguedadPuesto;

                var Nocturno = totales.Find(p => p.Concepto.Equals("Nocturno"));
                var Diurno = totales.Find(p => p.Concepto.Equals("Diurno"));
                var Mixto = totales.Find(p => p.Concepto.Equals("Mixto"));

                int totalNocturno = Nocturno == null ? 0 : Nocturno.Valor;
                int totalDiurno = Diurno == null ? 0 : Diurno.Valor;
                int totalMixto = Mixto == null ? 0 : Mixto.Valor;
                int totalJornada = totalNocturno + totalDiurno + totalMixto;
                DTOResumenJornadaLaboral dtJornadaLaboral = new DTOResumenJornadaLaboral();

                dtJornadaLaboral.CantidadNocturno = totalNocturno;
                dtJornadaLaboral.PorcentajeNocturno = CalcularPorcentaje(totalNocturno, totalJornada);

                dtJornadaLaboral.CantidadDiurno = totalDiurno;
                dtJornadaLaboral.PorcentajeDiurno = CalcularPorcentaje(totalDiurno, totalJornada);

                dtJornadaLaboral.CantidadMixto = totalMixto;
                dtJornadaLaboral.PorcentajeMixto = CalcularPorcentaje(totalMixto, totalJornada);
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

                dtResumenEscolaridad.CantidadSinFormacion = totalsinFormacion;
                dtResumenEscolaridad.PorcentajeSinFormacion = CalcularPorcentaje(totalsinFormacion, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadPrimaria = totalprimaria;
                dtResumenEscolaridad.PorcentajePrimaria = CalcularPorcentaje(totalprimaria, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadSecundaria = totalsecundaria;
                dtResumenEscolaridad.PorcentajeSecundaria = CalcularPorcentaje(totalsecundaria, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadPreparatoria = totalpreparatoriaBachillerato;
                dtResumenEscolaridad.PorcentajePreparatoria = CalcularPorcentaje(totalpreparatoriaBachillerato, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadTecnicoSuperior = totaltecnicoSuperior;
                dtResumenEscolaridad.PorcentajeTecnicoSuperior = CalcularPorcentaje(totaltecnicoSuperior, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadLicenciatura = totallicenciatura;
                dtResumenEscolaridad.PorcentajeLicenciatura = CalcularPorcentaje(totallicenciatura, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadMaestria = totalmaestria;
                dtResumenEscolaridad.PorcentajeMaestria = CalcularPorcentaje(totalmaestria, totalNivelesEstudios);

                dtResumenEscolaridad.CantidadDoctorado = totaldoctorado;
                dtResumenEscolaridad.PorcentajeDoctorado = CalcularPorcentaje(totaldoctorado, totalNivelesEstudios);
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

        private static Graficas_GUIAII FindGrafica(List<Graficas_GUIAII> rango, string concepto)
        {
            return rango.Find(p => string.Equals(p.concepto?.Trim(), concepto, StringComparison.OrdinalIgnoreCase));
        }

        private static Graficas_GUIAII FindGraficaContains(List<Graficas_GUIAII> rango, string conceptoParcial)
        {
            return rango.Find(p => p.concepto != null && p.concepto.Trim().Contains(conceptoParcial, StringComparison.OrdinalIgnoreCase));
        }

        private static DTONom35CategoryDomain MapGraficaCategoria(Graficas_GUIAII grafica)
        {
            if (grafica == null)
            {
                return new DTONom35CategoryDomain();
            }

            return new DTONom35CategoryDomain
            {
                NuloValue = grafica.Nulo,
                NuloPorcentaje = (double)grafica.PNulo,
                BajoValue = grafica.Bajo,
                BajoPorcentaje = (double)grafica.PBajo,
                MedioValue = grafica.Medio,
                MedioPorcentaje = (double)grafica.PMedio,
                AltoValue = grafica.Alto,
                AltoPorcentaje = (double)grafica.PAlto,
                MuyAltoValue = grafica.MuyAlto,
                MuyAltoPorcentaje = (double)grafica.PMuyAlto
            };
        }

        private static double CalcularPorcentaje(int valor, int total)
        {
            if (total <= 0)
            {
                return 0;
            }

            return (double)decimal.Round((decimal)valor / total * 100, 2);
        }
    }
}
