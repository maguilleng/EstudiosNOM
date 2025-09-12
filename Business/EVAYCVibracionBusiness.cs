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
    public class EVAYCVibracionBusiness : GenericBusiness<DTOAYCVibracion, EvAycVibracion>, IEVAYCVibracionBusiness
    {
        private IEVAYCVibracionRepository evrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVAYCVibracionBusiness(ESTUDIOS_NOM35Context context, IEVAYCVibracionRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            evrepo = repository;
            contexto = context;
        }
        public EvAycVibracion getEvaluacion(int IdTarea)
        {
            var evIluminacion = (from e in context.EvAycVibracions where e.Idtarea == IdTarea select e).FirstOrDefault();

            return evIluminacion;
        }

        public string updatEvaluacion(EvAycVibracion _evVibracion)
        {
            try
            {
                var evVibracion = (from e in context.EvAycVibracions where e.Idtarea == _evVibracion.Idtarea select e).FirstOrDefault();
                evVibracion.Intensidad = _evVibracion.Intensidad != null ? _evVibracion.Intensidad : evVibracion.Intensidad;
                evVibracion.SegmentosCorporales = _evVibracion.SegmentosCorporales != null ? _evVibracion.SegmentosCorporales : evVibracion.SegmentosCorporales;
                evVibracion.CualSegmentario = _evVibracion.CualSegmentario != null ? _evVibracion.CualSegmentario : evVibracion.CualSegmentario;
                evVibracion.Observaciones = _evVibracion.Observaciones != null ? _evVibracion.Observaciones : evVibracion.Observaciones;

                context.SaveChanges();
                return "La Evaluación de Agentes y Condiciones VIBRACIÓN ha sido actulizada con éxito";

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }        
    }
}
