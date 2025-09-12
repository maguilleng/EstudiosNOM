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
    public class EVNOM36ResultadosController : ControllerBase
    {
        private IEVNOM36ResultadosBusiness Nom036ResultBuss { get; set; }

        public EVNOM36ResultadosController(IEVNOM36ResultadosBusiness business)
        {
            Nom036ResultBuss = business;
        }

        [HttpPost]
        public ActionResult registraResultadosNOM36([FromBody] List<DTONOM36Resultados> resultados)
        {
            try
            {
                var result = Nom036ResultBuss.Add(resultados);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        [HttpPost]
        [Route("actualizaResultadosNOM36")]
        public ActionResult actualizaResultadosNOM36([FromBody] List<NomResultado> resultados)
        {
            try
            {
                var result = Nom036ResultBuss.actualizaResultadosNOM36(resultados);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
