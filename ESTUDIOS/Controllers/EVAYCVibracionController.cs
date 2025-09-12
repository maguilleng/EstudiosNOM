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
    public class EVAYCVibracionController : ControllerBase
    {
        private IEVAYCVibracionBusiness EvaVibracionBuss { get; set; }

        public EVAYCVibracionController(IEVAYCVibracionBusiness business)
        {
            EvaVibracionBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOAYCVibracion Evaluacion)
        {
            try
            {
                var result = EvaVibracionBuss.Add(Evaluacion);
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
            EvAycVibracion result = EvaVibracionBuss.getEvaluacion(IdTarea);
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
        public ActionResult actualizaEvaluacion([FromBody] EvAycVibracion Evaluacion)
        {
            try
            {
                var result = EvaVibracionBuss.updatEvaluacion(Evaluacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
