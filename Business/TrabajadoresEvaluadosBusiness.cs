using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using System.Data;

namespace Business
{

    public class TrabajadoresEvaluadosBusiness : GenericBusiness<DTOTrabajadoresEvaluados, TrabajadoresEstudio>, ITrabajadoresEvaluadosBusiness
    {
        private ITrabajadoresEvaluadosRepository trabajadoresEvaRepo;
        private IEVNutricionalBusiness evNutricionalBuss;
        private IEVNOM36ResultadosBusiness resultadosNOM35Buss;
        private IEstudiosBusiness estudiosbuss;
        private IEVMusculoesqueleticosBusiness evMusculoBuss;
        private ILinksRepository linksRepo;
        //private ITrabajadoresEvaluadosBusiness trabajadoresEvaluadosBuss;
        private ESTUDIOS_NOM35Context contexto;

        public TrabajadoresEvaluadosBusiness(ESTUDIOS_NOM35Context context, ITrabajadoresEvaluadosRepository repository, IMapper mapper,
            IEstudiosBusiness estudiosBiz, IEVNutricionalBusiness IevNutricionalBiz, IEVMusculoesqueleticosBusiness IevMusculoBiz,
            ILinksRepository linksRepo, IEVNOM36ResultadosBusiness resultadoNOM35Repository)
          : base(context, repository, mapper)
        {
            trabajadoresEvaRepo = repository;
            contexto = context;
            this.resultadosNOM35Buss = resultadoNOM35Repository;
            this.evNutricionalBuss = IevNutricionalBiz;
            this.evMusculoBuss = IevMusculoBiz;
            this.estudiosbuss = estudiosBiz;
            this.linksRepo = linksRepo;
        }
        public TrabajadoresEstudio getEvaluacionesxLink(Guid Link)
        {
            try
            {
                var trabajadoresEvaluados = context.TrabajadoresEstudios.FirstOrDefault(t => t.Link.HasValue && t.Link.Value.Equals(Link));
                if (trabajadoresEvaluados != null)
                {
                    return trabajadoresEvaluados;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TrabajadoresEstudio getEvaluaciones(int Idtrabajador)
        {
            try
            {
                var trabajadoresEvaluados = (from e in context.TrabajadoresEstudios where e.Idtrabajador == Idtrabajador select e).Include(p => p.EvMuscoloesqueleticos).Include(p => p.EvEstadoNutricionals).Include(p => p.Actividades).ThenInclude(p => p.Tareas).FirstOrDefault();
                if (trabajadoresEvaluados != null)
                {
                    return trabajadoresEvaluados;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string updateTrabajadoresEvalaudos(TrabajadoresEstudio _trabajadoresEstudio)
        {
            var trabajadores_evaluados = (from e in context.TrabajadoresEstudios where e.Idtrabajador == _trabajadoresEstudio.Idtrabajador select e).FirstOrDefault();

            if (trabajadores_evaluados != null)
            {
                try
                {
                    trabajadores_evaluados.Evaluador = _trabajadoresEstudio.Evaluador != null ? _trabajadoresEstudio.Evaluador : trabajadores_evaluados.Evaluador;
                    trabajadores_evaluados.FechaEvaluacion = _trabajadoresEstudio.FechaEvaluacion != null ? _trabajadoresEstudio.FechaEvaluacion : trabajadores_evaluados.FechaEvaluacion;
                    trabajadores_evaluados.Nombre = _trabajadoresEstudio.Nombre != null ? _trabajadoresEstudio.Nombre : trabajadores_evaluados.Nombre;
                    trabajadores_evaluados.Sexo = _trabajadoresEstudio.Sexo != null ? _trabajadoresEstudio.Sexo : trabajadores_evaluados.Sexo;
                    trabajadores_evaluados.Edad = _trabajadoresEstudio.Edad != null ? _trabajadoresEstudio.Edad : trabajadores_evaluados.Edad;
                    trabajadores_evaluados.EstadoCivil = _trabajadoresEstudio.EstadoCivil != null ? _trabajadoresEstudio.EstadoCivil : trabajadores_evaluados.EstadoCivil;
                    trabajadores_evaluados.NivelEstudio = _trabajadoresEstudio.NivelEstudio != null ? _trabajadoresEstudio.NivelEstudio : trabajadores_evaluados.NivelEstudio;
                    trabajadores_evaluados.TipoContratacion = _trabajadoresEstudio.TipoContratacion != null ? _trabajadoresEstudio.TipoContratacion : trabajadores_evaluados.TipoContratacion;
                    trabajadores_evaluados.TipoPersonal = _trabajadoresEstudio.TipoPersonal != null ? _trabajadoresEstudio.TipoPersonal : trabajadores_evaluados.TipoPersonal;
                    trabajadores_evaluados.ExperienciaLaboral = _trabajadoresEstudio.ExperienciaLaboral != null ? _trabajadoresEstudio.ExperienciaLaboral : trabajadores_evaluados.ExperienciaLaboral;
                    trabajadores_evaluados.TipoJornada = _trabajadoresEstudio.TipoJornada != null ? _trabajadoresEstudio.TipoJornada : trabajadores_evaluados.TipoJornada;
                    trabajadores_evaluados.RotaTurnos = _trabajadoresEstudio.RotaTurnos != null ? _trabajadoresEstudio.RotaTurnos : trabajadores_evaluados.RotaTurnos;
                    trabajadores_evaluados.Horario = _trabajadoresEstudio.Horario != null ? _trabajadoresEstudio.Horario : trabajadores_evaluados.Horario;
                    trabajadores_evaluados.TipoPuesto = _trabajadoresEstudio.TipoPuesto != null ? _trabajadoresEstudio.TipoPuesto : trabajadores_evaluados.TipoPuesto;
                    trabajadores_evaluados.AntiguedadPuesto = _trabajadoresEstudio.AntiguedadPuesto != null ? _trabajadoresEstudio.AntiguedadPuesto : trabajadores_evaluados.AntiguedadPuesto;
                    trabajadores_evaluados.AntiguedadCategoria = _trabajadoresEstudio.AntiguedadCategoria != null ? _trabajadoresEstudio.AntiguedadCategoria : trabajadores_evaluados.AntiguedadCategoria;
                    trabajadores_evaluados.JornadaTrabajo = _trabajadoresEstudio.JornadaTrabajo != null ? _trabajadoresEstudio.JornadaTrabajo : trabajadores_evaluados.JornadaTrabajo;
                    trabajadores_evaluados.PuestoCategoria = _trabajadoresEstudio.PuestoCategoria != null ? _trabajadoresEstudio.PuestoCategoria : trabajadores_evaluados.PuestoCategoria;
                    trabajadores_evaluados.DepartamentoArea = _trabajadoresEstudio.DepartamentoArea != null ? _trabajadoresEstudio.DepartamentoArea : trabajadores_evaluados.DepartamentoArea;
                    trabajadores_evaluados.InstalacionOficinaTaller = _trabajadoresEstudio.InstalacionOficinaTaller != null ? _trabajadoresEstudio.InstalacionOficinaTaller : trabajadores_evaluados.InstalacionOficinaTaller;
                    trabajadores_evaluados.AreaFisica = _trabajadoresEstudio.AreaFisica != null ? _trabajadoresEstudio.AreaFisica : trabajadores_evaluados.AreaFisica;
                    trabajadores_evaluados.DescripcionPuesto = _trabajadoresEstudio.DescripcionPuesto != null ? _trabajadoresEstudio.DescripcionPuesto : trabajadores_evaluados.DescripcionPuesto;
                    trabajadores_evaluados.Activo = _trabajadoresEstudio.Activo != null ? _trabajadoresEstudio.Activo : trabajadores_evaluados.Activo;
                    trabajadores_evaluados.Region = _trabajadoresEstudio.Region != null ? _trabajadoresEstudio.Region : trabajadores_evaluados.Region;
                    trabajadores_evaluados.Ficha = _trabajadoresEstudio.Ficha != null ? _trabajadoresEstudio.Ficha : trabajadores_evaluados.Ficha;
                    trabajadores_evaluados.NumHijos = _trabajadoresEstudio.NumHijos != null ? _trabajadoresEstudio.NumHijos : trabajadores_evaluados.NumHijos;
                    trabajadores_evaluados.PuestosHaTenido = _trabajadoresEstudio.PuestosHaTenido != null ? _trabajadoresEstudio.PuestosHaTenido : trabajadores_evaluados.PuestosHaTenido;
                    trabajadores_evaluados.RotacionGuardia = _trabajadoresEstudio.RotacionGuardia != null ? _trabajadoresEstudio.RotacionGuardia : trabajadores_evaluados.RotacionGuardia;
                    trabajadores_evaluados.HorasExtraSemana = _trabajadoresEstudio.HorasExtraSemana != null ? _trabajadoresEstudio.HorasExtraSemana : trabajadores_evaluados.HorasExtraSemana;
                    trabajadores_evaluados.TieneOtroTrabajo = _trabajadoresEstudio.TieneOtroTrabajo != null ? _trabajadoresEstudio.TieneOtroTrabajo : trabajadores_evaluados.TieneOtroTrabajo;
                    trabajadores_evaluados.HorasExtraOtroTrabajo = _trabajadoresEstudio.HorasExtraOtroTrabajo != null ? _trabajadoresEstudio.HorasExtraOtroTrabajo : trabajadores_evaluados.HorasExtraOtroTrabajo;

                    context.SaveChanges();
                    return "La actualización de la evaluación al trabajador: " + trabajadores_evaluados.Nombre + " fue exítosa.";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "La empresa no existe, ingrese correctamente los datos por favor";
            }
        }

        public ApiResponse<DTOTrabajadoresEvaluados> registraEvaluacionOnLine(DTOEvaluacionOnline DTOEvaluacion)
        {
            ApiResponse<DTOTrabajadoresEvaluados> ApiResponseEmpleadoEmpleado = new ApiResponse<DTOTrabajadoresEvaluados>();
            try
            {
                Link link = linksRepo.FindBy(l => (l.Link1 == DTOEvaluacion.GuidLink))?.FirstOrDefault();

                if (link != null)
                {
                    if (link.Vigencia.HasValue)
                    {
                        var today = DateTime.Now;
                        if ((link.Vigencia.Value - today).Days < 0)
                        {
                            ApiResponseEmpleadoEmpleado.IsSuccesfull = false;
                            ApiResponseEmpleadoEmpleado.ErrorDetails = "Link Inválido";
                            return ApiResponseEmpleadoEmpleado;
                        }
                    }

                    if (!link.Estatus.HasValue || !link.Estatus.Value)
                    {
                        ApiResponse<DTOEstudios> estudio = new ApiResponse<DTOEstudios>();

                        TrabajadoresEstudio trabajadorEvaluado = mapper.Map<DTOTrabajadoresEvaluados, TrabajadoresEstudio>(DTOEvaluacion.evaluacion);

                        estudio = estudiosbuss.getEstudiobyLink(DTOEvaluacion.GuidLink, true);

                        trabajadorEvaluado.Idestudio = estudio.ResponseData.Idestudio;
                        trabajadorEvaluado = trabajadoresEvaRepo.Add(trabajadorEvaluado);
                        context.SaveChanges();

                        DTOEvaluacion.nutricional.Idempleado = trabajadorEvaluado.Idtrabajador;
                        evNutricionalBuss.Add(DTOEvaluacion.nutricional);

                        DTOEvaluacion.musculoesqueleticos.ForEach(item => item.Idempleado = trabajadorEvaluado.Idtrabajador);
                        evMusculoBuss.Add(DTOEvaluacion.musculoesqueleticos);

                        if (link.TipoLink.Value == (int)TipoEnlace.USO_PERSONAL || link.TipoLink.Value == (int)TipoEnlace.USO_UNICO)
                        {
                            link.Estatus = true;
                            link = linksRepo.Update(link);
                            context.SaveChanges();
                        }

                        ApiResponseEmpleadoEmpleado.IsSuccesfull = true;
                        ApiResponseEmpleadoEmpleado.ResponseData = mapper.Map<TrabajadoresEstudio, DTOTrabajadoresEvaluados>(trabajadorEvaluado);

                        return ApiResponseEmpleadoEmpleado;
                    }

                }

                ApiResponseEmpleadoEmpleado.IsSuccesfull = false;
                ApiResponseEmpleadoEmpleado.ErrorDetails = "Link Inválido";
                return ApiResponseEmpleadoEmpleado;
            }
            catch (Exception ex)
            {
                ApiResponseEmpleadoEmpleado.IsSuccesfull = false;
                ApiResponseEmpleadoEmpleado.ErrorDetails = ex.InnerException.ToString();
                return ApiResponseEmpleadoEmpleado;
            }
        }

        public ApiResponse<List<DTOTrabajadoresEvaluados>> registraEvaluacionOffLine (List<DTOEvaluacionOffline> DTOEvaluacion)
        {
           
            try
            {
                ApiResponse<List<DTOTrabajadoresEvaluados>> ApiResponseEmpleados = new ApiResponse<List<DTOTrabajadoresEvaluados>>();
                List<DTOTrabajadoresEvaluados> empleadoevaluados = new List<DTOTrabajadoresEvaluados>();

                foreach (var valores in DTOEvaluacion)
                {
                    TrabajadoresEstudio trabajadorEvaluado = mapper.Map<DTOTrabajadoresEvaluados, TrabajadoresEstudio>(valores.evaluacion);
                    trabajadorEvaluado = trabajadoresEvaRepo.Add(trabajadorEvaluado);
                    context.SaveChanges();

                    if(valores.resultados?.Count > 0)
                    {
                        try
                        {
                            foreach (var valoresResultados in valores.resultados)
                            {
                                valoresResultados.Idempleado = trabajadorEvaluado.Idtrabajador;
                                resultadosNOM35Buss.Add(valoresResultados);
                            }
                            DTOTrabajadoresEvaluados empleadoevaluado = new DTOTrabajadoresEvaluados();
                            empleadoevaluado = mapper.Map<TrabajadoresEstudio, DTOTrabajadoresEvaluados>(trabajadorEvaluado);
                            empleadoevaluados.Add(empleadoevaluado);
                        }
                        catch (Exception ex)
                        {
                            trabajadoresEvaRepo.Delete(trabajadorEvaluado);
                            context.SaveChanges();
                            ApiResponseEmpleados.IsSuccesfull = false;
                            ApiResponseEmpleados.ErrorDetails = ex.InnerException.ToString();
                            return ApiResponseEmpleados;
                        }
                    }
                    
                }

                ApiResponseEmpleados.IsSuccesfull = true;
                ApiResponseEmpleados.ResponseData = empleadoevaluados;
                return ApiResponseEmpleados;
            }
            catch (Exception ex)
            {
                ApiResponse<List<DTOTrabajadoresEvaluados>> ApiResponseEmpleados = new ApiResponse<List<DTOTrabajadoresEvaluados>>();
                ApiResponseEmpleados.IsSuccesfull = false;
                ApiResponseEmpleados.ErrorDetails = ex.InnerException.ToString();
                return ApiResponseEmpleados;
            }
        }
    }
}
