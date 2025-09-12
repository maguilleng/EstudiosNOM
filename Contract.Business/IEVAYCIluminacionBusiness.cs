using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVAYCIluminacionBusiness : IGenericBusiness<DTOAYCIluminacion>
    {
        public EvAycIluminacion getEvaluacion(int IdTarea);
        public string updateIluminacion(EvAycIluminacion evaluacion);
    }
}
