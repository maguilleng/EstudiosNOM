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
    public class EVAYCIluminacionController : ControllerBase
    {
        private IEVAYCIluminacionBusiness EvaIluminacionBuss { get; set; }

        public EVAYCIluminacionController(IEVAYCIluminacionBusiness business)
        {
            EvaIluminacionBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOAYCIluminacion EvaIluminacion)
        {
            try
            {
                var result = EvaIluminacionBuss.Add(EvaIluminacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpGet]
        public ActionResult getEvaluacion([FromQuery] int IdTarea)
        {
            EvAycIluminacion result = EvaIluminacionBuss.getEvaluacion(IdTarea);
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }

        }
        [HttpPost]
        [Route("actualizaAYCIluminacion")]
        public ActionResult actualizaEvaluacion([FromBody] EvAycIluminacion EvaIluminacion)
        {
            try
            {
                var result = EvaIluminacionBuss.updateIluminacion(EvaIluminacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
