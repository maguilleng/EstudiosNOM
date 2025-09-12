using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Contract.Business
{
    public interface IReportesBusiness
    {
        ApiResponse<DTOReporteNom35GuiaII> GetReporteGuiaII(int idEstudio);
    }
}
