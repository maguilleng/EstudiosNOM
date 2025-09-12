using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface IEmpresasBusiness : IGenericBusiness<DTOEmpresas>
    {
        Empresa getEmpresaRFC(string RFC);
        List<Empresa> getEmpresaEv(bool evalua);
        String updateEmpresa(Empresa empresa);
        List<Empresa> getEmpresas();
        List<Empresa> getEmpresasInactivas();
    }
}
