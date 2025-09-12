using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using System.Data;

namespace Business
{
    public class TareasBusiness: GenericBusiness<DTOTareas, Tarea>, ITareasBusiness
    {
        private ITareasRepository tareasrepo;
        private ESTUDIOS_NOM35Context contexto;

        public TareasBusiness(ESTUDIOS_NOM35Context context, ITareasRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            tareasrepo = repository;
            contexto = context;
        }


        public string updateTarea(Tarea _tarea)
        {
            var Tarea = (from e in context.Tareas where e.Idtarea == _tarea.Idtarea select e).FirstOrDefault();

            if (Tarea != null)
            {
                try
                {
                    Tarea.Titulo = _tarea.Titulo != null ? Tarea.Titulo = _tarea.Titulo : Tarea.Titulo;
                    Tarea.TiempoTarea = _tarea.TiempoTarea != null ? Tarea.TiempoTarea = _tarea.TiempoTarea : Tarea.TiempoTarea;
                    Tarea.Descripcion = _tarea.Descripcion != null ? Tarea.Descripcion = _tarea.Descripcion : Tarea.Descripcion;
                    Tarea.Ubicacion = _tarea.Ubicacion != null ? Tarea.Ubicacion = _tarea.Ubicacion : Tarea.Ubicacion;
                    Tarea.Frecuencia = _tarea.Frecuencia != null ? Tarea.Frecuencia = _tarea.Frecuencia : Tarea.Frecuencia;
                    Tarea.TipoTarea = _tarea.TipoTarea != null ? Tarea.TipoTarea = _tarea.TipoTarea : Tarea.TipoTarea;
                    Tarea.Colectiva = _tarea.Colectiva != null ? Tarea.Colectiva = _tarea.Colectiva : Tarea.Colectiva;
                    Tarea.Evnom036Transportar = _tarea.Evnom036Transportar != null ? Tarea.Evnom036Transportar = _tarea.Evnom036Transportar : Tarea.Evnom036Transportar;
                    Tarea.Evnom036Levantar = _tarea.Evnom036Levantar != null ? Tarea.Evnom036Levantar = _tarea.Evnom036Levantar : Tarea.Evnom036Levantar;
                    Tarea.Evnom036Equipo = _tarea.Evnom036Equipo != null ? Tarea.Evnom036Equipo = _tarea.Evnom036Equipo : Tarea.Evnom036Equipo;
                    Tarea.EvagentesCondiciones = _tarea.EvagentesCondiciones != null ? Tarea.EvagentesCondiciones = _tarea.EvagentesCondiciones : Tarea.EvagentesCondiciones;
                    Tarea.Rula = _tarea.Rula != null ? Tarea.Rula = _tarea.Rula : Tarea.Rula;
                    Tarea.Reba = _tarea.Reba != null ? Tarea.Reba = _tarea.Reba : Tarea.Reba;
                    Tarea.Niosh = _tarea.Niosh != null ? Tarea.Niosh = _tarea.Niosh : Tarea.Niosh;
                    Tarea.Owas = _tarea.Owas != null ? Tarea.Owas = _tarea.Owas : Tarea.Owas;
                    Tarea.Rosa = _tarea.Rosa != null ? Tarea.Rosa = _tarea.Rosa : Tarea.Rosa;
                    Tarea.Activo = _tarea.Activo != null ? Tarea.Activo = _tarea.Activo : Tarea.Activo;


                    context.SaveChanges();
                    return "La actualización de la tarea: " + Tarea.Titulo + " fue exítosa.";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "La empresa no existe, ingrese correctamente los datos por favor";
            }
        }
    }
}
