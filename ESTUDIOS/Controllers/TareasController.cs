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
    public class TareasController : ControllerBase
    { 
     private ITareasBusiness tareasBuss { get; set; }

    public TareasController(ITareasBusiness business)
    {
            tareasBuss = business;
    }

    [HttpPost]
    public ActionResult registraTarea([FromBody] DTOTareas tarea)
    {
        try
        {
            var result = tareasBuss.Add(tarea);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.ToString());
        }
    }

    [HttpPost]
    [Route("actualizaTarea")]
    public ActionResult actualizaTarea([FromBody]Tarea _Tarea)
    {
        String resultado = "";
        try
        {
            resultado = tareasBuss.updateTarea(_Tarea);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException.ToString());
        }
    }
        
    }
}
