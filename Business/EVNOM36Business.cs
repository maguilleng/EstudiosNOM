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
    public class EVNOM36Business : GenericBusiness<DTONOM036Apartado, NomApartado>,  IEvNOM036Business
    {
        private IEVNOM36Repository Nom36Rep;
        private ESTUDIOS_NOM35Context contexto;

        public EVNOM36Business(ESTUDIOS_NOM35Context context, IEVNOM36Repository repository, IMapper mapper)
          : base(context, repository, mapper)
        {
            Nom36Rep = repository;
            contexto = context;
        }
        public DTONOM036Apartado getCuestionarios(int IdApartado, int idEmpleado)
        {

            try
            {
                var cuestionariosNOM36 = (from e in context.NomApartados
                                          join p in context.NomPreguntas on e.Idapartado equals p.Idapartado
                                          join r in context.NomRespuestas on new
                                          {
                                              CutomerId = p.Idpregunta,
                                              esr = p.Idapartado
                                          }
                                          equals new
                                          {
                                              CutomerId = r.Idpregunta,
                                              esr = r.Idapartado
                                          }
                                          join rs in context.NomResultados on new
                                          {
                                              CutomerIds = r.Idpregunta,
                                              esr = r.Idapartado,
                                              resp = r.Idrespuesta,
                                              empleado = idEmpleado
                                          }
                                            equals new
                                            {
                                                CutomerIds = rs.Idpregunta,
                                                esr = rs.Idapartado,
                                                resp = rs.Idrespuesta.Value,
                                                empleado = rs.Idempleado

                                            } into gj
                                          from x in gj.DefaultIfEmpty()
                                          where e.Idapartado == IdApartado
                                          select new DTOGetCuestionarioNOM36

                                          {
                                              IdApartado = e.Idapartado,
                                              Indice = e.Indice,
                                              Titulo = e.Titulo,
                                              Descripción = e.Descripcion,
                                              IdPregunta = p.Idpregunta,
                                              IdApartadoPregunta = p.Idapartado,
                                              IndicePregunta = p.Indice,
                                              TituloPregunta = p.Titulo,
                                              DescripcionPregunta = p.Descripcion,
                                              IdseccionPregunta = p.IdseccionPregunta,
                                              DependeDe = p.DependeDe,
                                              TipoPregunta = p.TipoPregunta,
                                              IdRespuesta = r.Idrespuesta,
                                              IDpreguntaResp = r.Idpregunta,
                                              IdApartadoResp = r.Idapartado,
                                              IndiceResp = r.Indice,
                                              DescripcionResp = r.Descripcion,
                                              Nivel = r.Nivel,
                                              Valor = r.Valor,
                                              ImagenPregunta = r.ImagenPregunta,
                                              TipoRespuesta = r.TipoRespuesta,
                                              Imagen = r.Imagen,
                                              IdRespSeleccionada = (x.Idrespuesta.ToString() == null ? 0 : x.Idrespuesta),
                                              FrecuenciaHora = x.FrecuenciaHora,
                                              PesoCarga = x.PesoCarga,
                                              TRANSID = x.Transid
                                             
                                          }

                                          ).ToList().OrderBy(rs => rs.IdPregunta);

                if (cuestionariosNOM36.Count() > 0)
                {
                    DTONOM036Apartado entApartado = new DTONOM036Apartado();
                    entApartado.Preguntas = new List<DTONOM036Preguntas>();

                    DTONOM036Preguntas entPreguntas = new DTONOM036Preguntas();
                    entPreguntas.Respuestas = new List<DTONOM036Respuestas>();

                    DTONOM036Respuestas entRespuestas = new DTONOM036Respuestas();

                    //APARTADO
                    entApartado.IDApartado = cuestionariosNOM36.Select(id => id.IdApartado).FirstOrDefault();
                    entApartado.Indice = cuestionariosNOM36.Select(i => i.Indice).FirstOrDefault();
                    entApartado.Titulo = cuestionariosNOM36.Select(t => t.Titulo).FirstOrDefault();
                    entApartado.Descripcion = cuestionariosNOM36.Select(d => d.Descripción).FirstOrDefault();

                    int contador = 1;
                    int idpreguntainicial = cuestionariosNOM36.Select(id => id.IdPregunta).FirstOrDefault();
                    int idpreguntafinal = cuestionariosNOM36.Count();
                    int idRespuesta = 0;

                    foreach (var resultados in cuestionariosNOM36)
                    {
                        if (resultados.IdPregunta != idpreguntainicial)
                        {
                            //LLenamos preguntas
                            entApartado.Preguntas.Add(entPreguntas);
                            //Abrimos nuevas preguntas
                            entPreguntas = new DTONOM036Preguntas();
                            //Abrimos nuevas respuestas
                            entPreguntas.Respuestas = new List<DTONOM036Respuestas>();
                            idpreguntainicial = resultados.IdPregunta;
                        }

                        //PREGUNTAS
                        entPreguntas.IdPregunta = resultados.IdPregunta;
                        entPreguntas.IdApartado = resultados.IdApartadoPregunta;
                        entPreguntas.Titulo = resultados.TituloPregunta;
                        entPreguntas.Indice = resultados.IndicePregunta;
                        entPreguntas.Descripcion = resultados.DescripcionPregunta;
                        entPreguntas.TipoPregunta = resultados.TipoPregunta;
                        entPreguntas.DependeDe = resultados.DependeDe;
                        entPreguntas.IdseccionPregunta = resultados.IdseccionPregunta;
                        //RESPUESTAS
                        entRespuestas.IdRespuesta = resultados.IdRespuesta;
                        entRespuestas.IDpregunta = resultados.IDpreguntaResp;
                        entRespuestas.IdApartado = resultados.IdApartadoResp;
                        entRespuestas.Indice = resultados.IndiceResp;
                        entRespuestas.Descripcion = resultados.DescripcionResp;
                        entRespuestas.Nivel = resultados.Nivel;
                        entRespuestas.Valor = resultados.Valor;
                        entRespuestas.Imagen = resultados.Imagen;
                        entRespuestas.IdRespSeleccionada = resultados.IdRespSeleccionada.ToString();
                        entRespuestas.PesoCarga = resultados.PesoCarga;
                        entRespuestas.FrecuenciaHora = resultados.FrecuenciaHora;
                        entRespuestas.TRANSID = resultados.TRANSID;

                        entPreguntas.Respuestas.Add(entRespuestas);
                        entRespuestas = new DTONOM036Respuestas();
                        idRespuesta = resultados.IdRespuesta;

                        
                        if (idpreguntafinal == contador)
                        { 
                        //LLenamos preguntas finales
                        entApartado.Preguntas.Add(entPreguntas);
                        }
                        contador++;
                    }

                    return entApartado;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

    }
}
