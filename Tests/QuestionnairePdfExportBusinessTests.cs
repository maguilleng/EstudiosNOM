using System;
using System.Linq;
using Business.Pdf;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EstudiosNOM.Tests
{
    public class QuestionnairePdfExportBusinessTests
    {
        [Fact]
        public void GetQuestionnairesForStudy_ReturnsEmployeeItems()
        {
            var options = new DbContextOptionsBuilder<ESTUDIOS_NOM35Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ESTUDIOS_NOM35Context(options);

            var empresa = new Empresa { Rfc = "RFC123", RazonSocial = "Cliente Demo", DireccionFiscal = "X", Giro = "Y", RepresentanteLegal = "Z" };
            var estudio = new Estudio { Idestudio = 1, Rfcempresa = empresa.Rfc, RfcempresaEva = empresa.Rfc, Titulo = "NOM-35", FechaCaptura = DateTime.Today, Activo = true, RfcempresaNavigation = empresa };
            var trabajador = new TrabajadoresEstudio { Idtrabajador = 10, Nombre = "Empleado Uno", Idestudio = estudio.Idestudio, FechaEvaluacion = DateTime.Today };
            var apartado = new NomApartado { Idapartado = 5, Titulo = "Seccion A", Indice = 1 };
            var pregunta = new NomPregunta { Idpregunta = 7, Idapartado = apartado.Idapartado, Titulo = "Pregunta 1", Indice = 1 };
            var respuesta = new NomRespuesta { Idrespuesta = 9, Idapartado = apartado.Idapartado, Idpregunta = pregunta.Idpregunta, Descripcion = "Siempre" };
            var resultado = new NomResultado { Transid = 1, Idempleado = trabajador.Idtrabajador, Idapartado = apartado.Idapartado, Idpregunta = pregunta.Idpregunta, Idrespuesta = respuesta.Idrespuesta, PesoCarga = 5, FrecuenciaHora = 2 };

            context.Empresas.Add(empresa);
            context.Estudios.Add(estudio);
            context.TrabajadoresEstudios.Add(trabajador);
            context.NomApartados.Add(apartado);
            context.NomPreguntas.Add(pregunta);
            context.NomRespuestas.Add(respuesta);
            context.NomResultados.Add(resultado);
            context.SaveChanges();

            var business = new QuestionnairePdfExportBusiness(context);

            var result = business.GetQuestionnairesForStudy(estudio.Idestudio);

            Assert.Single(result);
            Assert.Equal(trabajador.Idtrabajador, result[0].EmployeeId);
            Assert.Single(result[0].Items);
            Assert.Contains("Peso carga", result[0].Items.First().Answer);
        }
    }
}
