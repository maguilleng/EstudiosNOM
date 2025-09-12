using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface ITareasBusiness : IGenericBusiness<DTOTareas>
    {
        String updateTarea(Tarea tarea);
    }
}
