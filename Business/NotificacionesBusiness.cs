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
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class NotificacionesBusiness : GenericBusiness<DTOCuerpoNotificaciones, CuerpoNotificacione>, INotificacionesBusiness
    {
        private INotificacionesRepository NotificacionesRepo;
        private ESTUDIOS_NOM35Context contexto;

        public NotificacionesBusiness(ESTUDIOS_NOM35Context context, INotificacionesRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            NotificacionesRepo = repository;
            contexto = context;
        }

        public ApiResponse<CuerpoNotificacione> getCuerpoNotificaciones(string norma)
        {
            var respuesta = new ApiResponse<CuerpoNotificacione>();

            try
            {
                var cuerpoNotificacion = (from e in context.CuerpoNotificaciones where e.Norma.Equals(norma) select e).FirstOrDefault();
                if (cuerpoNotificacion != null)
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = cuerpoNotificacion;
                    return respuesta;
                }
                else
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = cuerpoNotificacion;
                    respuesta.ErrorDetails = "No existe cuerpo para la notificación aún para la norma";
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
    }
}
