using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using System.Data;

namespace Business
{
    public class LinksBusiness : GenericBusiness<DTOLinks, Link>, ILinksBusiness
    {
        private ILinksRepository LinksRepo;
        private ESTUDIOS_NOM35Context contexto;

        public LinksBusiness(ESTUDIOS_NOM35Context context, ILinksRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            LinksRepo = repository;
            contexto = context;
        }
        public ApiResponse<List<Link>> getLinks(int idEstudio)
        {
            var respuesta = new ApiResponse<List<Link>>();

            try
            {
                var links = (from e in context.Links where e.Idestudio == idEstudio select e).ToList();
                if (links != null)
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = links;
                    return respuesta;
                }
                else {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = links;
                    respuesta.ErrorDetails = "No existen Links aún para el estudio";
                    return respuesta;
                }
            }

            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return respuesta;
            }
        }
        public ApiResponse<Link> getStatusLink(Guid GUID)
        {
            var respuesta = new ApiResponse<Link>();

            try
            {
                var links = (from e in context.Links where e.Link1 == GUID select e).FirstOrDefault();
                if (links != null)
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = links;
                    return respuesta;
                }
                else
                {
                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = links;
                    respuesta.ErrorDetails = "No existe el Link";
                    return respuesta;
                }
            }

            catch (Exception ex)
            {
                respuesta.IsSuccesfull = false;
                respuesta.ErrorDetails = ex.InnerException.ToString();
                return respuesta;
            }
        }

        public ApiResponse<string> actualizaEstatusLink(Guid Link)
        {
            var respuesta = new ApiResponse<string>();
            var link = (from e in context.Links where e.Link1 == Link select e).FirstOrDefault();

            if (link != null)
            {
                try
                {
                    link.Estatus = true;
                    context.SaveChanges();

                    respuesta.IsSuccesfull = true;
                    respuesta.ResponseData = "El estatus del Link cambio a utilizado (true)";
                    return respuesta;

                }
                catch (Exception ex)
                {
                    respuesta.IsSuccesfull = false;
                    respuesta.ErrorDetails = ex.InnerException.ToString();
                    return respuesta;
                }
            }
            else
            {
                respuesta.IsSuccesfull = false;
                respuesta.ResponseData = "El link no existe";
                return respuesta;
            }
        }
    }
}
