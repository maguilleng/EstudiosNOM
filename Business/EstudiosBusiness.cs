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
    public class EstudiosBusiness : GenericBusiness<DTOEstudios, Estudio>, IEstudiosBusiness
    {
        private IEstudiosRepository Estudrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EstudiosBusiness(ESTUDIOS_NOM35Context context, IEstudiosRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            Estudrepo = repository;
            contexto = context;
        }
        public List<Estudio> getEstudios()
        {
            try
            {
                var estudios = (from e in context.Estudios select e).Include(p => p.TrabajadoresEstudios).ToList();
                if (estudios != null)
                {
                    return estudios;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }
             public Estudio getEstudioId(int Id)
        {
            try
            {
                var estudio = (from e in context.Estudios where e.Idestudio == Id select e).Include(p => p.TrabajadoresEstudios).FirstOrDefault();
                if (estudio != null)
                {
                    return estudio;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }
        public ApiResponse<DTOEstudios> getEstudiobyLink(Guid Link, bool sinIDEstudio)
        {
            var respuesta = new ApiResponse<DTOEstudios>();
            DTOEstudios estudio ;

            try
            {                if (!sinIDEstudio)
                {
                     estudio = (from e in context.Estudios
                                   join p in context.Links on e.Idestudio equals p.Idestudio
                                   where p.Link1 == Link
                                   select
                        new DTOEstudios
                        {
                            Idestudio = 0,
                            Titulo = e.Titulo,
                            Subtitulo = e.Subtitulo,
                            Instalacion = e.Instalacion,
                            FechaCaptura = e.FechaCaptura,
                            FechaInforme = e.FechaInforme,
                            Rfcempresa = e.Rfcempresa,
                            RfcempresaEva = e.Rfcempresa,
                            GuiaIi = e.GuiaIi,
                            GuiaIii = e.GuiaIii,
                            Activo = e.Activo,
                            Idsync = e.Idsync
                        }
                               ).FirstOrDefault();
                }
                else {
                     estudio = (from e in context.Estudios
                                   join p in context.Links on e.Idestudio equals p.Idestudio
                                   where p.Link1 == Link
                                   select
                        new DTOEstudios
                        {
                            Idestudio = e.Idestudio,
                            Titulo = e.Titulo,
                            Subtitulo = e.Subtitulo,
                            Instalacion = e.Instalacion,
                            FechaCaptura = e.FechaCaptura,
                            FechaInforme = e.FechaInforme,
                            Rfcempresa = e.Rfcempresa,
                            RfcempresaEva = e.Rfcempresa,
                            GuiaIi = e.GuiaIi,
                            GuiaIii = e.GuiaIii,
                            Activo = e.Activo,
                            Idsync = e.Idsync
                        }
                                   ).FirstOrDefault();
                }

                if (estudio != null)
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = estudio;
                    return respuesta;
                }
                else
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = estudio;
                respuesta.ErrorDetails = "No existe el Estudio";
                return respuesta;
            }
        }

            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return respuesta;
            }
}

        public List<Estudio> getEstudioActivo(bool Activo)
        {
            try
            {
                var estudios = (from e in context.Estudios where e.Activo == Activo select e).Include(p => p.TrabajadoresEstudios).Include(p=>p.RfcempresaEvaNavigation).Include(p=>p.RfcempresaNavigation).ToList();
                if (estudios != null)
                {
                    return estudios;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }

        public string updateEstudio(Estudio _estudio)
        {
            var estudio = (from e in context.Estudios where e.Idestudio == _estudio.Idestudio select e).FirstOrDefault();

            if (estudio != null)
            {
                try
                {
                    estudio.Titulo = _estudio.Titulo != null ? estudio.Titulo = _estudio.Titulo : estudio.Titulo;
                    estudio.Subtitulo = _estudio.Subtitulo != null ? estudio.Subtitulo = _estudio.Subtitulo : estudio.Subtitulo;
                    estudio.Instalacion = _estudio.Instalacion != null ? estudio.Instalacion = _estudio.Instalacion : estudio.Instalacion;
                    estudio.FechaCaptura = _estudio.FechaCaptura != null ? estudio.FechaCaptura = _estudio.FechaCaptura : estudio.FechaCaptura;
                    estudio.FechaInforme = _estudio.FechaInforme != null ? estudio.FechaInforme = _estudio.FechaInforme : estudio.FechaInforme;
                    estudio.Rfcempresa = _estudio.Rfcempresa != null ? estudio.Rfcempresa = _estudio.Rfcempresa : estudio.Rfcempresa;
                    estudio.RfcempresaEva = _estudio.RfcempresaEva != null ? estudio.RfcempresaEva = _estudio.RfcempresaEva : estudio.RfcempresaEva;
                    estudio.GuiaIi = _estudio.GuiaIi != null ? estudio.GuiaIi = _estudio.GuiaIi : estudio.GuiaIi;
                    estudio.GuiaIii = _estudio.GuiaIii != null ? estudio.GuiaIii = _estudio.GuiaIii : estudio.GuiaIii;
                    estudio.Activo = _estudio.Activo;
                    
                    context.SaveChanges();
                    return "La actualización del estudio: " + _estudio.Titulo + " fue exítosa.";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "El estudio no existe, ingrese correctamente los datos por favor";
            }
        }
    }
}

