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
    public class EVNOM036Controller : ControllerBase
    {
        private IEvNOM036Business Nom036Buss { get; set; }

        public EVNOM036Controller(IEvNOM036Business business)
        {
            Nom036Buss = business;
        }

        [HttpGet]
        [Route("getCuestionarios")]
        public ActionResult getCuestionarios([FromQuery] int IdApartado, int idEmpleado)
        {
            var result = Nom036Buss.getCuestionarios(IdApartado, idEmpleado);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
