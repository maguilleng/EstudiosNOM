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
    public class TrabajadoresEvaluadosController : ControllerBase
    {

        private ITrabajadoresEvaluadosBusiness trabajadoresEvaBuss { get; set; }
        private IEVNutricionalBusiness EvaNutriconalBuss { get; set; }
        private IEstudiosBusiness studBuss { get; set; }
        private IEVMusculoesqueleticosBusiness EvMusculoBuss { get; set; }

        public TrabajadoresEvaluadosController(
            ITrabajadoresEvaluadosBusiness business,
            IEstudiosBusiness studBuss
            )
        {
            trabajadoresEvaBuss = business;
            this.studBuss = studBuss;
        }

        [HttpPost]
        public ActionResult registraEvaluacion([FromBody] DTOTrabajadoresEvaluados trabajadorEva)
        {
            trabajadorEva.FechaEvaluacion = DateTime.Now;
            try
            {
                if(trabajadorEva.Link.HasValue)
                {
                    ApiResponse<DTOEstudios> response = studBuss.getEstudiobyLink(trabajadorEva.Link.Value, true);
                    if(response.IsSuccesfull && response.ResponseData != null)
                    {
                        trabajadorEva.Idestudio = response.ResponseData.Idestudio;                        
                    }
                }

                if(trabajadorEva.Idestudio > 0)
                {
                    var result = trabajadoresEvaBuss.Add(trabajadorEva);
                    return Ok(result);
                }

                return BadRequest(new ApiResponse<string> { ErrorDetails = "Idestudio es requerido"});
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string> { ErrorDetails = ex.InnerException.ToString() } );
            }
        }

        [HttpPost]
        [Route("Dinamyc")]
        public ActionResult registraEvaluacionOnLine([FromBody] DTOEvaluacionOnline DTOEvaluacion)
        {
            try
            {
                ApiResponse<DTOTrabajadoresEvaluados> ApiResponseEmpleadoEmpleado = new ApiResponse<DTOTrabajadoresEvaluados>();
                ApiResponseEmpleadoEmpleado = trabajadoresEvaBuss.registraEvaluacionOnLine(DTOEvaluacion);

                return Ok(ApiResponseEmpleadoEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("registraEvaluacionOffLine")]
        public ActionResult registraEvaluacionOffLine([FromBody] List<DTOEvaluacionOffline> DTOEvaluacion)
        {
            try
            {
                ApiResponse<List<DTOTrabajadoresEvaluados>> ApiResponseEmpleadoEmpleado = new ApiResponse<List<DTOTrabajadoresEvaluados>>();
                ApiResponseEmpleadoEmpleado = trabajadoresEvaBuss.registraEvaluacionOffLine(DTOEvaluacion);

                return Ok(ApiResponseEmpleadoEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPost]
        [Route("actualizaEvaluaciones")]
        public ActionResult actualizaTrabajadoresEvaluados([FromBody] TrabajadoresEstudio _trabajadoresEva)
        {
            String resultado = "";
            try
            {
                resultado = trabajadoresEvaBuss.updateTrabajadoresEvalaudos(_trabajadoresEva);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        [HttpGet]
        [Route("getEvaluaciones")]
        public ActionResult getEvaluaciones([FromQuery] int IdTrabajador)

        { 
            var result = trabajadoresEvaBuss.getEvaluaciones(IdTrabajador);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No existe el trabajador");
            }
        }

        [HttpGet]
        [Route("getEvaluacionesxLink")]
        public ActionResult getEvaluacionesxLink([FromQuery] Guid Link)

        {
            var result = trabajadoresEvaBuss.getEvaluacionesxLink(Link);
            ApiResponse<TrabajadoresEstudio> respuesta = new ApiResponse<TrabajadoresEstudio>();

            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = result;
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }
    }
}
