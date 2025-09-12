using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVAYCAmbTermicoBusiness : IGenericBusiness<DTOAYCAmbTermico>
    {
        public EvAycAmbientermico getEvaluacion(int IdTarea);
        public string updatEvaluacion(EvAycAmbientermico evaluacion);
    }
}
