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
    public class LinksController : ControllerBase
    {
        private ILinksBusiness linksBuss { get; set; }

        public LinksController(ILinksBusiness business)
        {
            linksBuss = business;
        }

        [HttpPost]
        public ActionResult registraLinks([FromBody] List<DTOLinks> Link)
        {
            ApiResponse<List<DTOLinks>> respuesta= new ApiResponse<List<DTOLinks>>();

            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = linksBuss.Add(Link);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }
        [HttpGet]
        public ActionResult getLinksIDStudio([FromQuery] int idEstudio)
        {
            var result = linksBuss.getLinks(idEstudio);
            try { 
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        [Route("getStatusLink")]
        public ActionResult getStatusLink([FromQuery] Guid GUID)
        {
            var result = linksBuss.getStatusLink(GUID);

            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }
        [HttpDelete]
        public ActionResult deleteLink([FromBody] DTOLinks Link)
        {
            ApiResponse<DTOLinks> respuesta = new ApiResponse<DTOLinks>();
           
            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = linksBuss.Delete(Link);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }
        [HttpPut]
        public ActionResult putLink([FromBody] DTOLinks Link)
        {
            ApiResponse<DTOLinks> respuesta = new ApiResponse<DTOLinks>();

            try
            {
                respuesta.IsSuccesfull = true;
                respuesta.ResponseData = linksBuss.Update(Link);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return BadRequest(respuesta);
            }
        }

        [HttpGet]
        [Route("actualizaEstatusLink")]
        public ActionResult actualizaEstatusLink([FromQuery] Guid Link)

        {

           var respuesta = linksBuss.actualizaEstatusLink(Link);

            try
            {
                //respuesta.IsSuccesfull = true;
                //respuesta.ResponseData = respuesta;
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
