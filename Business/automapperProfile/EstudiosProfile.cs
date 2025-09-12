using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.automapperProfile
{
    public class EstudiosProfile : Profile
    {
        public EstudiosProfile()
        {
            CreateMap<DTOEmpresas, Empresa>();
            CreateMap<Empresa, DTOEmpresas>();
            CreateMap<DTOEstudios, Estudio>();
            CreateMap<Estudio, DTOEstudios>();
            CreateMap<DTOTrabajadoresEvaluados, TrabajadoresEstudio>();
            CreateMap<TrabajadoresEstudio, DTOTrabajadoresEvaluados>();
            CreateMap<DTOEVNutricional, EvEstadoNutricional>();
            CreateMap<EvEstadoNutricional, DTOEVNutricional>();
            CreateMap<DTOActividades, Actividade>();
            CreateMap<Actividade, DTOActividades>();
            CreateMap<DTOTareas, Tarea>();
            CreateMap<Tarea, DTOTareas>();
            CreateMap<DTOEVMuscoloesqueleticos, EvMuscoloesqueletico>();
            CreateMap<EvMuscoloesqueletico, DTOEVMuscoloesqueleticos>();
            CreateMap<DTONOM036Apartado, NomApartado>();
            CreateMap<NomApartado, DTONOM036Apartado>();
            CreateMap<DTONOM36Resultados, NomResultado>();
            CreateMap<NomResultado, DTONOM36Resultados>();
            CreateMap<DTOAYCIluminacion, EvAycIluminacion>();
            CreateMap<EvAycIluminacion, DTOAYCIluminacion>();
            CreateMap<DTOAYCAmbSonoro, EvAycAmbientesonoro>();
            CreateMap<EvAycAmbientesonoro, DTOAYCAmbSonoro>();
            CreateMap<DTOAYCAmbTermico, EvAycAmbientermico>();
            CreateMap<EvAycAmbientermico, DTOAYCAmbTermico>();
            CreateMap<DTOAYCVibracion, EvAycVibracion>();
            CreateMap<EvAycVibracion, DTOAYCVibracion>();
            CreateMap<DTOLinks, Link>();
            CreateMap<Link, DTOLinks>();
            CreateMap<DTOCuerpoNotificaciones, CuerpoNotificacione>();
            CreateMap<CuerpoNotificacione, DTOCuerpoNotificaciones>();
        }    
    }
}
