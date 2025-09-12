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
    public class EmpresasBusiness : GenericBusiness<DTOEmpresas, Empresa>, IEmpresasBusiness
    {
        private IEmpresasRepository empresasRepo;
        private ESTUDIOS_NOM35Context contexto;

        public EmpresasBusiness(ESTUDIOS_NOM35Context context, IEmpresasRepository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            empresasRepo = repository;
            contexto = context;
        }
        public List<Empresa> getEmpresas()
        {
            try
            {
                var empresa = (from e in context.Empresas where e.Activo == true select e).ToList();
            if (empresa != null)
            {
                return empresa;
            }
            else { return null; }
            }
            catch
            {
                return null;
            }
        }
        public List<Empresa> getEmpresasInactivas()
        {
            try
            {
                var empresa = (from e in context.Empresas where e.Activo == false select e).ToList();
                if (empresa != null)
                {
                    return empresa;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }

        public Empresa getEmpresaRFC(string RFC)
        {
            try
            {
                var empresa = (from e in context.Empresas where e.Rfc == RFC select e).FirstOrDefault();
                if (empresa != null)
                {
                    return empresa;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }
        public List<Empresa> getEmpresaEv(bool evalua)
        {
            try
            {
                var empresa = (from e in context.Empresas where e.Evaluadora == evalua select e).ToList();
                if (empresa != null)
                {
                    return empresa;
                }
                else { return null; }
            }
            catch
            {
                return null;
            }
        }

        public string updateEmpresa(Empresa _empresa)
        {
            var empresa = (from e in context.Empresas where e.Rfc == _empresa.Rfc select e).FirstOrDefault();

            if (empresa != null)
            {
                try
                {
                    empresa.Evaluadora = _empresa.Evaluadora ;
                    empresa.RazonSocial = _empresa.RazonSocial != null ? empresa.RazonSocial = _empresa.RazonSocial : empresa.RazonSocial;
                    empresa.DireccionFiscal = _empresa.DireccionFiscal != null ? empresa.DireccionFiscal = _empresa.DireccionFiscal : empresa.DireccionFiscal;
                    empresa.RepresentanteLegal = _empresa.RepresentanteLegal != null ? empresa.RepresentanteLegal = _empresa.RepresentanteLegal : empresa.RepresentanteLegal;
                    empresa.ResponsableInforme = _empresa.ResponsableInforme != null ? empresa.ResponsableInforme = _empresa.ResponsableInforme : empresa.ResponsableInforme;
                    empresa.CapacidadInstalada = _empresa.CapacidadInstalada != null ? empresa.CapacidadInstalada = _empresa.CapacidadInstalada : empresa.CapacidadInstalada;
                    empresa.Giro = _empresa.Giro != null ? empresa.Giro = _empresa.Giro : empresa.Giro;
                    empresa.Proceso = _empresa.Proceso != null ? empresa.Proceso = _empresa.Proceso : empresa.Proceso;
                    empresa.Email = _empresa.Email != null ? empresa.Email = _empresa.Email : empresa.Email;
                    empresa.Activo = _empresa.Activo != null ? empresa.Activo = _empresa.Activo : empresa.Activo;
                    empresa.InstalacionOficinaBase = _empresa.InstalacionOficinaBase != null ? empresa.InstalacionOficinaBase = _empresa.InstalacionOficinaBase : empresa.InstalacionOficinaBase;

                    context.SaveChanges();
                    return "La actualización de la empresa: " + _empresa.RazonSocial + " fue exítosa.";
                }
                catch (Exception ex)
                {
                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "La empresa no existe, ingrese correctamente los datos por favor";
            }
        }
    }
}
