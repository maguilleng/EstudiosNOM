using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Data.repository;
using Data.Models;

namespace Contract.Business
{
    public interface IEstudiosBusiness : IGenericBusiness<DTOEstudios>
    {   
        Estudio getEstudioId(int Id);
        List<Estudio> getEstudioActivo(bool activo);
        String updateEstudio(Estudio estudio);
        List<Estudio> getEstudios();
        ApiResponse<DTOEstudios> getEstudiobyLink(Guid Link, bool sinEstudio);
    }
}
