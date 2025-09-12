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
    public class EmpresasController : ControllerBase
    {
        private IEmpresasBusiness empresasBuss { get; set; }

        public EmpresasController(IEmpresasBusiness business)
        {
            empresasBuss = business;
        }

        [HttpPost]
        public ActionResult registraEmpresa([FromBody] DTOEmpresas Empresa)
        {
            try
            {
                var result = empresasBuss.Add(Empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString()) ;
            }
        }
        [HttpPost]
        [Route("actualizaEmpresa")]
        public ActionResult actualizaEmpresa([FromBody] Empresa _empresa)
        {
            String resultado = "";
                try
                {
                    resultado = empresasBuss.updateEmpresa(_empresa);
                    return Ok(resultado);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.ToString());
                }
        }

        [HttpGet]
        public ActionResult GetEmpresas()
        {           
            List<Empresa> result = empresasBuss.getEmpresas();
            if (result != null)
            {
                return Ok(result);
            }
            else {
                return BadRequest("No existen aún empresas que mostrar.");
            }
        }

        [HttpGet]
        [Route("getEmpresasInactivas")]
        public ActionResult GetEmpresasInactivas()
        {
            try {
                List<Empresa> result = empresasBuss.getEmpresasInactivas();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("No existen aún empresas que mostrar.");
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }



















        [HttpGet]
        [Route("getEmpresaRFC")]
        public ActionResult getEmpresaRFC([FromQuery] string RFC)
        {
            Empresa result = empresasBuss.getEmpresaRFC(RFC);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("La empresa no existe en la Base de Datos.");
            }
        }

        [HttpGet]
        [Route("getEmpresaEv")]
        public ActionResult getEmpresaEv([FromQuery] bool Evalua)
        {
            List<Empresa> result = empresasBuss.getEmpresaEv(Evalua);
            if (result.Count != 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No existen empresas " + (Evalua == true ? "Evaluadoras " : "a evaluar ") + "aún");
            }
        }

    }
}
