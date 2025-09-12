using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVAYCVibracionBusiness : IGenericBusiness<DTOAYCVibracion>
    {
        public EvAycVibracion getEvaluacion(int IdTarea);
        public string updatEvaluacion(EvAycVibracion evaluacion);
    }
}
