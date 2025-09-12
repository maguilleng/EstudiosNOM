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
    public class EVNutricionalBusiness : GenericBusiness<DTOEVNutricional, EvEstadoNutricional>, IEVNutricionalBusiness
    {
        private IEVNutricionalRepository EvNutricionalrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVNutricionalBusiness(ESTUDIOS_NOM35Context context, IEVNutricionalRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            EvNutricionalrepo = repository;
            contexto = context;
        }

        public string updateEVNutricional(EvEstadoNutricional __EvNutricional)
        {
            var EvNutricional = (from e in context.EvEstadoNutricionals where e.Idempleado == __EvNutricional.Idempleado select e).FirstOrDefault();

            var NombreTrabajador = (from e in context.TrabajadoresEstudios where e.Idtrabajador == __EvNutricional.Idempleado select e).FirstOrDefault();

            if (EvNutricional != null)
            {
                try
                {
                    EvNutricional.Peso = __EvNutricional.Peso != 0 ? EvNutricional.Peso = __EvNutricional.Peso : EvNutricional.Peso;
                    EvNutricional.Altura = __EvNutricional.Altura != 0 ? EvNutricional.Altura = __EvNutricional.Altura : EvNutricional.Altura;
                    EvNutricional.PerimetroAbdominal = __EvNutricional.PerimetroAbdominal != 0 ? EvNutricional.PerimetroAbdominal = __EvNutricional.PerimetroAbdominal : EvNutricional.PerimetroAbdominal;
                    EvNutricional.Ims = __EvNutricional.Ims != 0 ? EvNutricional.Ims = __EvNutricional.Ims : EvNutricional.Ims;
                    

                    context.SaveChanges();
                    return "La actualización de la evaluación Estado Nutricional al trabajador: " + NombreTrabajador.Nombre + " fue exítosa.";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "La Evaluación no existe, ingrese correctamente los datos por favor";
            }
        }
    }
}
