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
    public class EVAYCIluminacionBusiness : GenericBusiness<DTOAYCIluminacion, EvAycIluminacion>, IEVAYCIluminacionBusiness
    {
        private IEVAYCIluminacionRepository Iluminacionrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVAYCIluminacionBusiness(ESTUDIOS_NOM35Context context, IEVAYCIluminacionRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            Iluminacionrepo = repository;
            contexto = context;
        }
        public EvAycIluminacion getEvaluacion(int IdTarea)
        {
            var evIluminacion = (from e in context.EvAycIluminacions where e.Idtarea == IdTarea select e).FirstOrDefault();

            return evIluminacion;
        }

        public string updateIluminacion(EvAycIluminacion _evIluminacion)
        {
            try
            {
                var evIluminacion = (from e in context.EvAycIluminacions where e.Idtarea == _evIluminacion.Idtarea select e).FirstOrDefault();
                evIluminacion.Fuente = _evIluminacion.Fuente != null ? _evIluminacion.Fuente : evIluminacion.Fuente;
                evIluminacion.Intensidad = _evIluminacion.Intensidad != null ? _evIluminacion.Intensidad : evIluminacion.Intensidad;
                evIluminacion.Observaciones = _evIluminacion.Observaciones != null ? _evIluminacion.Observaciones : evIluminacion.Observaciones;

                context.SaveChanges();
                return "La Evaluación de Agentes y Condiciones ILUMINACION ha sido actulizada con éxito";

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }        
    }
}
