using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVAYCAmbSonoroBusiness : IGenericBusiness<DTOAYCAmbSonoro>
    {
        public EvAycAmbientesonoro getEvaluacion(int IdTarea);
        public string updatEvaluacion(EvAycAmbientesonoro evaluacion);
    }
}
