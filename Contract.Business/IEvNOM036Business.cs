using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Data.repository;
using Data.Models;
namespace Contract.Business
{
   public interface IEvNOM036Business : IGenericBusiness<DTONOM036Apartado> 
    {
        DTONOM036Apartado getCuestionarios(int idApartado, int idEmpleado);
    }
}
