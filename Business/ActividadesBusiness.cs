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
    public class ActividadesBusiness : GenericBusiness<DTOActividades, Actividade>, IActividadesBusiness
    {
        private IActividadesRepository Actividadesrepo;
        private ESTUDIOS_NOM35Context contexto;

        public ActividadesBusiness(ESTUDIOS_NOM35Context context, IActividadesRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            Actividadesrepo = repository;
            contexto = context;
        }


        public string updateActividad(Actividade _actividad)
        {
            var Actividad = (from e in context.Actividades where e.Idactividad == _actividad.Idactividad select e).FirstOrDefault();

            if (Actividad != null)
            {
                try
                {
                    Actividad.Titulo = _actividad.Titulo != null ? Actividad.Titulo = _actividad.Titulo : Actividad.Titulo;
                    Actividad.Actividad = _actividad.Actividad != null ? Actividad.Actividad = _actividad.Actividad : Actividad.Actividad;
                    Actividad.Descripcion = _actividad.Descripcion != null ? Actividad.Descripcion = _actividad.Descripcion : Actividad.Descripcion;
                    Actividad.Materiales = _actividad.Materiales != null ? Actividad.Materiales = _actividad.Materiales : Actividad.Materiales;
                    Actividad.MaquinasEquipos = _actividad.MaquinasEquipos != null ? Actividad.MaquinasEquipos = _actividad.MaquinasEquipos : Actividad.MaquinasEquipos;
                    Actividad.Dotacion = _actividad.Dotacion != null ? Actividad.Dotacion = _actividad.Dotacion : Actividad.Dotacion;
                    Actividad.ProtecionPersonal = _actividad.ProtecionPersonal != null ? Actividad.ProtecionPersonal = _actividad.ProtecionPersonal : Actividad.ProtecionPersonal;
                    Actividad.Activo = _actividad.Activo != null ? Actividad.Activo = _actividad.Activo : Actividad.Activo;

                    context.SaveChanges();
                    return "La actualización de la actividad: " + Actividad.Titulo + " fue exítosa.";
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
