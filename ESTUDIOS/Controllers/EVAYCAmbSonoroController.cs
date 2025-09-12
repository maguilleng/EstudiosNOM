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
    public class EVAYCAmbSonoroController : ControllerBase
    {
        private IEVAYCAmbSonoroBusiness EvaAmbSonoroBuss { get; set; }

        public EVAYCAmbSonoroController(IEVAYCAmbSonoroBusiness business)
        {
            EvaAmbSonoroBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOAYCAmbSonoro EvaIluminacion)
        {
            try
            {
                var result = EvaAmbSonoroBuss.Add(EvaIluminacion);
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
            EvAycAmbientesonoro result = EvaAmbSonoroBuss.getEvaluacion(IdTarea);
            try
            {

                return Ok(result);
            }
                    

             catch (Exception ex) 
            { return BadRequest(ex.InnerException.ToString());                
            }

        }
        [HttpPost]
        [Route("actualizaEvaluacion")]
        public ActionResult actualizaEvaluacion([FromBody] EvAycAmbientesonoro Evaluacion)
        {
            try
            {
                var result = EvaAmbSonoroBuss.updatEvaluacion(Evaluacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
