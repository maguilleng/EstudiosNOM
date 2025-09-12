using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ClosedXML.Excel;
using System.IO;
using System.Threading.Tasks;
using Data;

namespace ESTUDIOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private INotificacionesBusiness notificacionesBuss { get; set; }

        private readonly IEmailService mailServiceBusinnes;
       
        public NotificacionesController(INotificacionesBusiness business, IEmailService mailService, IConfigurationProvider configuration)
        {
            notificacionesBuss = business;
            this.mailServiceBusinnes = mailService;

        }

        [HttpPost]
        public ActionResult registraCuerpoNootificaciones([FromBody] DTOCuerpoNotificaciones cuerpoNotificaciones)
        {
            ApiResponse<DTOCuerpoNotificaciones> respuesta = new ApiResponse<DTOCuerpoNotificaciones>();

            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = notificacionesBuss.Add(cuerpoNotificaciones);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }

        [HttpPut]
        public ActionResult putCuerpoNotificaciones([FromBody] DTOCuerpoNotificaciones cuerpoNotificaciones)
        {
            ApiResponse<DTOCuerpoNotificaciones> respuesta = new ApiResponse<DTOCuerpoNotificaciones>();

            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = notificacionesBuss.Update(cuerpoNotificaciones);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }

        public ActionResult getCuerpoNotificaciones([FromQuery] string norma)
        {
            ApiResponse<CuerpoNotificacione> respuesta = new ApiResponse<CuerpoNotificacione>();
            try
            {
             respuesta = notificacionesBuss.getCuerpoNotificaciones(norma);
            
                return Ok(respuesta);
            }
            catch
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost]
        [Route("EnvioNotificaciones")]
        public async Task<ActionResult> EnvioNotificaciones([FromBody] DTOEnvioNotificacion notificaciones)
        {
            ApiResponse<DTOEnvioNotificacion> respuesta = new ApiResponse<DTOEnvioNotificacion>();
  
            await mailServiceBusinnes.sendEmailAsync(notificaciones);
            respuesta.IsSuccesfull = true;
            return Ok(respuesta);
        }

    }
}
