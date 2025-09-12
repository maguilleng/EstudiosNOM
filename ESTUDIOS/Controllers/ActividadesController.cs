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
using System.IO;

namespace ESTUDIOS.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private IActividadesBusiness actividadesBuss { get; set; }

        public ActividadesController(IActividadesBusiness business)
        {
            actividadesBuss = business;
        }

        [HttpPost]
        public ActionResult registraActividad([FromBody] DTOActividades actividad)
        {
            try
            {
                var result = actividadesBuss.Add(actividad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("actualizaActividad")]
        public ActionResult actualizaActividad([FromBody] Actividade _Actividad)
        {
            String resultado = "";
            try
            {
                resultado = actividadesBuss.updateActividad(_Actividad);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
