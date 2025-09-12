using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Data.repository;
using Data.Models;
    namespace Contract.Business
{
    public interface IEVNOM36ResultadosBusiness : IGenericBusiness<DTONOM36Resultados>
    {
        //string registraResultados(List<DTONOM36Resultados> resultados);
        String actualizaResultadosNOM36(List<NomResultado> resultadosNOM36);
    }
}
