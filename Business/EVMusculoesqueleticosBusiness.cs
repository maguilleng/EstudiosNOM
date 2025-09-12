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
    public class EVMusculoesqueleticosBusiness : GenericBusiness<DTOEVMuscoloesqueleticos, EvMuscoloesqueletico>, IEVMusculoesqueleticosBusiness
    {
        private IEVMusculoesqueleticosRepository EvMusculoesqueleticosrepo;
        private ESTUDIOS_NOM35Context contexto;

        public EVMusculoesqueleticosBusiness(ESTUDIOS_NOM35Context context, IEVMusculoesqueleticosRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            EvMusculoesqueleticosrepo = repository;
            contexto = context;
        }

        public string updateEVNMuscoloesqueleticos(List<EvMuscoloesqueletico> __EvMuscoloesqueleticos)
        {
            string regiones = "Region(es) ";
            try
            {

                for (int i = 0; i < __EvMuscoloesqueleticos.Count(); i++)
                {

                    var EvNMuscoloesqueleticos = (from e in context.EvMuscoloesqueleticos where e.Idempleado == __EvMuscoloesqueleticos[i].Idempleado && e.Idregion == __EvMuscoloesqueleticos[i].Idregion select e).FirstOrDefault();

                    var NombreTrabajador = (from e in context.TrabajadoresEstudios where e.Idtrabajador == __EvMuscoloesqueleticos[i].Idempleado select e).FirstOrDefault();

                    if (EvNMuscoloesqueleticos != null)
                    {
                        EvNMuscoloesqueleticos.Molestias = __EvMuscoloesqueleticos[i].Molestias;
                        EvNMuscoloesqueleticos.Izquierdo = __EvMuscoloesqueleticos[i].Izquierdo;
                        EvNMuscoloesqueleticos.Derecho = __EvMuscoloesqueleticos[i].Derecho;
                        EvNMuscoloesqueleticos.Duracion = __EvMuscoloesqueleticos[i].Duracion;
                        EvNMuscoloesqueleticos.CambioPuesto = __EvMuscoloesqueleticos[i].CambioPuesto;
                        EvNMuscoloesqueleticos.Ult12M = __EvMuscoloesqueleticos[i].Ult12M;
                        EvNMuscoloesqueleticos.Tiempo = __EvMuscoloesqueleticos[i].Tiempo;
                        EvNMuscoloesqueleticos.DuracionEpisodio = __EvMuscoloesqueleticos[i].DuracionEpisodio;
                        EvNMuscoloesqueleticos.ImpedimentoTrabajo = __EvMuscoloesqueleticos[i].ImpedimentoTrabajo;
                        EvNMuscoloesqueleticos.TratamientoMedico = __EvMuscoloesqueleticos[i].TratamientoMedico;
                        EvNMuscoloesqueleticos.Ult7Dias = __EvMuscoloesqueleticos[i].Ult7Dias;
                        EvNMuscoloesqueleticos.Calificacion = __EvMuscoloesqueleticos[i].Calificacion;
                        EvNMuscoloesqueleticos.Factores = __EvMuscoloesqueleticos[i].Factores;

                        context.SaveChanges();
                        regiones = regiones +   __EvMuscoloesqueleticos[i].Idregion + "  se actualizo,";
                    }
                    else
                    {
                        regiones = regiones + __EvMuscoloesqueleticos[i].Idregion + "  no se actualizo,";
                    }

                }

                return regiones;
            }
                    catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }

        public void limpiaMuscoloesqueleticos(int idEmpleado)
        {
            contexto.EvMuscoloesqueleticos.RemoveRange(contexto.EvMuscoloesqueleticos.Where(x => x.Idempleado == idEmpleado));
            contexto.SaveChanges();
        }

        public List<EvMuscoloesqueletico> getEvMuscoloesqueleticos(int idEmpleado)
        { 
         var evmusculoesqueleticos  = (from e in context.EvMuscoloesqueleticos where e.Idempleado == idEmpleado select e).ToList();

            return evmusculoesqueleticos;
        }
    }
}
