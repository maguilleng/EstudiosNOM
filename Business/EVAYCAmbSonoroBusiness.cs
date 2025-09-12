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
    public class EVAYCAmbSonoroBusiness : GenericBusiness<DTOAYCAmbSonoro, EvAycAmbientesonoro>, IEVAYCAmbSonoroBusiness
    {
        private IEVAYCAmbSonoroRepository evrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVAYCAmbSonoroBusiness(ESTUDIOS_NOM35Context context, IEVAYCAmbSonoroRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            evrepo = repository;
            contexto = context;
        }
        public EvAycAmbientesonoro getEvaluacion(int IdTarea)
        {
            var evaluacion = (from e in context.EvAycAmbientesonoros where e.Idtarea == IdTarea select e).FirstOrDefault();

            return evaluacion;
        }

        public string updatEvaluacion(EvAycAmbientesonoro _evaluacion)
        {
            try
            {
                var evaluacion = (from e in context.EvAycAmbientesonoros where e.Idtarea == _evaluacion.Idtarea select e).FirstOrDefault();
                evaluacion.Fuente = _evaluacion.Fuente != null ? _evaluacion.Fuente : evaluacion.Fuente;
                evaluacion.Intensidad = _evaluacion.Intensidad != null ? _evaluacion.Intensidad : evaluacion.Intensidad;
                evaluacion.Continuidad = _evaluacion.Continuidad != null ? _evaluacion.Continuidad : evaluacion.Continuidad;
                evaluacion.Observaciones = _evaluacion.Observaciones != null ? _evaluacion.Observaciones : evaluacion.Observaciones;

                context.SaveChanges();
                return "La Evaluación de Agentes y Condiciones AMBIENTE SONORO ha sido actulizada con éxito";

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }        
    }
}
