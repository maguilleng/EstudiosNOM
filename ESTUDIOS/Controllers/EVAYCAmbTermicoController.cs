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
    public class EVAYCAmbTermicoController : ControllerBase
    {
        private IEVAYCAmbTermicoBusiness EvaAmbTermicoBuss { get; set; }

        public EVAYCAmbTermicoController(IEVAYCAmbTermicoBusiness business)
        {
            EvaAmbTermicoBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOAYCAmbTermico Evaluacion)
        {
            try
            {
                var result = EvaAmbTermicoBuss.Add(Evaluacion);
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
            EvAycAmbientermico result = EvaAmbTermicoBuss.getEvaluacion(IdTarea);
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
        [Route("actualizaEvaluacion")]
        public ActionResult actualizaEvaluacion([FromBody] EvAycAmbientermico Evaluacion)
        {
            try
            {
                var result = EvaAmbTermicoBuss.updatEvaluacion(Evaluacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
