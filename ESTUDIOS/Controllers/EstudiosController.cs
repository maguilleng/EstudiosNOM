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
namespace ESTUDIOS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosBusiness studBuss { get; set; }

        public EstudiosController(IEstudiosBusiness business)
        {
            studBuss = business;
        }

        [HttpPost]
        public ActionResult registraEstudio([FromBody] DTOEstudios Estudio)
        {
            try
            {
                var result = studBuss.Add(Estudio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        [HttpPost]
        [Route("actualizaEstudio")]
        public ActionResult actualizaEstudio([FromBody] Estudio _estudio)
        {
            String resultado = "";
            try
            {
                resultado = studBuss.updateEstudio(_estudio);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        [HttpGet]
        public ActionResult GetEstudios()
        {

            List<Estudio> result = studBuss.getEstudios();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No existen aún estudios que mostrar.");
            }
        }
        [HttpGet]
        [Route("getEstudiobyLink")]
        public ActionResult getEstudiobyLink([FromQuery] Guid LInk)
        {

            var result = studBuss.getEstudiobyLink(LInk, false);

            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
           
        }
        [HttpGet]
        [Route("getEstudioID")]
        public ActionResult getEstudioID([FromQuery] int Id)
        {
            Estudio result = studBuss.getEstudioId(Id);
            try
            {
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("El Estudio no existe en la Base de Datos.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpGet]
        [Route("getEstudioActivos")]
        public ActionResult getEstudioActivos([FromQuery] bool Activo)
        {
            try
            {
                List<Estudio> result = studBuss.getEstudioActivo(Activo);
                if (result.Count != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("No existen estudios " + (Activo == true ? "activos " : "inactivos ") + "aún");
                }
            }
            catch (Exception ex) { return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
