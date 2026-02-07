using System;
using System.IO;
using System.IO.Compression;
using Business.Pdf;
using Contract.Business;
using Data.Models;
using DTO;
using ESTUDIOS.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace EstudiosNOM.Tests
{
    public class ReportesControllerTests
    {
        [Fact]
        public void ExportarCuestionariosPdf_ReturnsZipWithPdf()
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
            var resultado = new NomResultado { Transid = 1, Idempleado = trabajador.Idtrabajador, Idapartado = apartado.Idapartado, Idpregunta = pregunta.Idpregunta, Idrespuesta = respuesta.Idrespuesta };

            context.Empresas.Add(empresa);
            context.Estudios.Add(estudio);
            context.TrabajadoresEstudios.Add(trabajador);
            context.NomApartados.Add(apartado);
            context.NomPreguntas.Add(pregunta);
            context.NomRespuestas.Add(respuesta);
            context.NomResultados.Add(resultado);
            context.SaveChanges();

            var questionnaireBusiness = new QuestionnairePdfExportBusiness(context);
            var trabajadoresMock = new Mock<ITrabajadoresEvaluadosBusiness>();
            var estudiosMock = new Mock<IEstudiosBusiness>();
            var reportesMock = new Mock<IReportesBusiness>();
            var env = new TestWebHostEnvironment();
            var optionsValue = Options.Create(new PdfExportSettings());

            var controller = new ReportesController(
                env,
                trabajadoresMock.Object,
                estudiosMock.Object,
                reportesMock.Object,
                questionnaireBusiness,
                optionsValue);

            var result = controller.ExportarCuestionariosPdf(estudio.Idestudio);

            Assert.NotNull(result);
            Assert.Equal("application/zip", result.ContentType);

            using var zipStream = new MemoryStream(result.FileContents);
            using var archive = new ZipArchive(zipStream, ZipArchiveMode.Read);
            Assert.Single(archive.Entries);
            Assert.EndsWith(".pdf", archive.Entries[0].Name);
        }

        private class TestWebHostEnvironment : IWebHostEnvironment
        {
            public string EnvironmentName { get; set; } = "Development";
            public string ApplicationName { get; set; } = "ESTUDIOS";
            public string WebRootPath { get; set; } = Directory.GetCurrentDirectory();
            public IFileProvider WebRootFileProvider { get; set; } = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            public string ContentRootPath { get; set; } = Directory.GetCurrentDirectory();
            public IFileProvider ContentRootFileProvider { get; set; } = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        }
    }
}
