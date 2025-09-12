using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVNutricionalBusiness : IGenericBusiness<DTOEVNutricional>
    {
        String updateEVNutricional(EvEstadoNutricional evEdoNutricional);
    }
}
