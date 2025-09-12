using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEVMusculoesqueleticosBusiness : IGenericBusiness<DTOEVMuscoloesqueleticos>
    {
        String updateEVNMuscoloesqueleticos(List<EvMuscoloesqueletico> evMusculoesqueletivos);
        public void limpiaMuscoloesqueleticos(int idEmpleado);

        public List<EvMuscoloesqueletico> getEvMuscoloesqueleticos(int idEmpleado);
    }
}
