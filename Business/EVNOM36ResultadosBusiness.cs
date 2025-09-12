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
    public class EVNOM36ResultadosBusiness : GenericBusiness<DTONOM36Resultados, NomResultado>, IEVNOM36ResultadosBusiness
    {
        private IEVNOM36ResultadosRepository Nom36ResultRep;
        private ESTUDIOS_NOM35Context contexto;

        public EVNOM36ResultadosBusiness(ESTUDIOS_NOM35Context context, IEVNOM36ResultadosRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            Nom36ResultRep = repository;
            contexto = context;
        }

        public string actualizaResultadosNOM36(List<NomResultado> resultados)
        {
            try
            {
                foreach (var _resultado in resultados)
                {
                    var resultadosNOM36 = (from e in context.NomResultados where e.Idapartado == _resultado.Idapartado && e.Idempleado == _resultado.Idempleado && e.Idpregunta == _resultado.Idpregunta select e).FirstOrDefault();
                    
                    if(resultadosNOM36 == null)
                    {
                        repository.Add(_resultado);
                    }
                    else
                    {
                        resultadosNOM36.Idrespuesta = _resultado.Idrespuesta; //!= 0 ? _resultado.Idrespuesta : resultadosNOM36.Idrespuesta;
                        resultadosNOM36.PesoCarga = _resultado.PesoCarga != null ? _resultado.PesoCarga : resultadosNOM36.PesoCarga;
                        resultadosNOM36.FrecuenciaHora = _resultado.FrecuenciaHora != null ? _resultado.FrecuenciaHora : resultadosNOM36.FrecuenciaHora;
                    }
                }
                context.SaveChanges();
                return "La actualización del apartado fue exítosa.";
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
    }
}
