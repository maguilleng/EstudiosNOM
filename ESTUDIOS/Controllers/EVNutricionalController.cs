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
    public class EVNutricionalController : ControllerBase
    {
        private IEVNutricionalBusiness EvaNutricionalBuss { get; set; }

        public EVNutricionalController(IEVNutricionalBusiness business)
        {
            EvaNutricionalBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOEVNutricional EvaNutricional)
        {
            try
            {
                var result = EvaNutricionalBuss.Add(EvaNutricional);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("actualizaEvEdoNutricional")]
        public ActionResult actualizaEvEdoNutricional([FromBody] EvEstadoNutricional _EvaEdoNutricional)
        {
            String resultado = "";
            try
            {
                resultado = EvaNutricionalBuss.updateEVNutricional(_EvaEdoNutricional);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
