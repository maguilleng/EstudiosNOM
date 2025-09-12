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
    public class EVAYCAmbTermicoBusiness : GenericBusiness<DTOAYCAmbTermico, EvAycAmbientermico>, IEVAYCAmbTermicoBusiness
    {
        private IEVAYCAmbTermicoRepository evrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVAYCAmbTermicoBusiness(ESTUDIOS_NOM35Context context, IEVAYCAmbTermicoRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            evrepo = repository;
            contexto = context;
        }
        public EvAycAmbientermico getEvaluacion(int IdTarea)
        {
            var evAmbTermico = (from e in context.EvAycAmbientermicos where e.Idtarea == IdTarea select e).FirstOrDefault();

            return evAmbTermico;
        }

        public string updatEvaluacion(EvAycAmbientermico _evaluacion)
        {
            try
            {
                var evaluacion = (from e in context.EvAycAmbientermicos where e.Idtarea == _evaluacion.Idtarea select e).FirstOrDefault();
                evaluacion.Percepcion = _evaluacion.Percepcion != null ? _evaluacion.Percepcion : evaluacion.Percepcion;
                evaluacion.EjemploPercepcion = _evaluacion.EjemploPercepcion != null ? _evaluacion.EjemploPercepcion : evaluacion.EjemploPercepcion;
                evaluacion.Intensidad = _evaluacion.Intensidad != null ? _evaluacion.Intensidad : evaluacion.Intensidad;
                evaluacion.Fuente = _evaluacion.Fuente != null ? _evaluacion.Fuente : evaluacion.Fuente;
                evaluacion.Observaciones = _evaluacion.Observaciones != null ? _evaluacion.Observaciones : evaluacion.Observaciones;

                context.SaveChanges();
                return "La Evaluación de Agentes y Condiciones AMBIENTE TERMICO ha sido actulizada con éxito";

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }        
    }
}
