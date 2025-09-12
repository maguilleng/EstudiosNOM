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
    public class EVMuscoloesqueleticosController : ControllerBase
    {
        private IEVMusculoesqueleticosBusiness EvaMusculoesqueleticosBuss { get; set; }

        public EVMuscoloesqueleticosController(IEVMusculoesqueleticosBusiness business)
        {
            EvaMusculoesqueleticosBuss = business;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] List<DTOEVMuscoloesqueleticos> EvaMusculoesqueleticos)
        {
            try
            {
                var result = EvaMusculoesqueleticosBuss.Add(EvaMusculoesqueleticos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("actualizaEvMusculoesqueliticos")]
        public ActionResult actualizaEvMusculoesqueliticos([FromBody] List<EvMuscoloesqueletico> _EvaMuscoloesqueleticos)
        {
            String resultado = "";
            try
            {
                resultado = EvaMusculoesqueleticosBuss.updateEVNMuscoloesqueleticos(_EvaMuscoloesqueleticos);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpGet]
        public ActionResult getEvMuscoloesqueleticos(int idEmpleado)
        {
            try
            {
                var resultado = EvaMusculoesqueleticosBuss.getEvMuscoloesqueleticos(idEmpleado);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
