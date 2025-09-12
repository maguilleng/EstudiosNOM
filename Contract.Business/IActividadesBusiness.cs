using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;
namespace Contract.Business
{
    public interface IActividadesBusiness : IGenericBusiness<DTOActividades>
    {
        String updateActividad(Actividade actividad);
    }
}
