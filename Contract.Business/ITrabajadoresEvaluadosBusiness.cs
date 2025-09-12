using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Data.repository;
using Data.Models;


namespace Contract.Business
{
    public interface ITrabajadoresEvaluadosBusiness : IGenericBusiness<DTOTrabajadoresEvaluados>
    {
        //    Empresa getEmpresaRFC(string RFC);
        //    List<Empresa> getEmpresaEv(bool evalua);
        String updateTrabajadoresEvalaudos(TrabajadoresEstudio trabajadoresEstudio);

        TrabajadoresEstudio getEvaluaciones(int idTrabajador);
        TrabajadoresEstudio getEvaluacionesxLink(Guid link);
        public ApiResponse<DTOTrabajadoresEvaluados> registraEvaluacionOnLine(DTOEvaluacionOnline DTOEvaluacion);
        public ApiResponse<List<DTOTrabajadoresEvaluados>> registraEvaluacionOffLine(List<DTOEvaluacionOffline> DTOEvaluacion);
    }
}
