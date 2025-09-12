using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using DTO;

namespace Contract.Business
{
    public interface ILinksBusiness : IGenericBusiness<DTOLinks>
    {
       ApiResponse<List<Link>> getLinks(int idEstudio);
        ApiResponse<Link> getStatusLink(Guid GUID);
        ApiResponse<string>  actualizaEstatusLink(Guid GUID);
    }
}
