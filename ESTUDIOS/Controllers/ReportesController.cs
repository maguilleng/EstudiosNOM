using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using WordText = DocumentFormat.OpenXml.Wordprocessing.Text;
using WordTable = DocumentFormat.OpenXml.Wordprocessing.Table;
using WordRun = DocumentFormat.OpenXml.Wordprocessing.Run;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using ESTUDIOS.OpenXML;
using System.IO.Compression;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Business.Pdf;
using Microsoft.Extensions.Options;
using DTO;

namespace ESTUDIOS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private IWebHostEnvironment hostEnvironment;
        private ITrabajadoresEvaluadosBusiness trabajadoresEvaBuss { get; set; }
        private IEstudiosBusiness estudiosBuss { get; set; }
        private IReportesBusiness reporteGuiaII { get; set; }
        private IQuestionnairePdfExportBusiness questionnairePdfExportBuss { get; set; }
        private PdfExportSettings pdfExportSettings { get; set; }

        public ReportesController(
            IWebHostEnvironment hostEnvironment,
            ITrabajadoresEvaluadosBusiness trabajadoresEvaBuss,
            IEstudiosBusiness estudiosBuss,
            IReportesBusiness reportbuss,
            IQuestionnairePdfExportBusiness questionnairePdfExportBuss,
            IOptions<PdfExportSettings> pdfExportOptions)
        {
            this.hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            this.trabajadoresEvaBuss = trabajadoresEvaBuss;
            this.estudiosBuss = estudiosBuss;
            this.reporteGuiaII = reportbuss;
            this.questionnairePdfExportBuss = questionnairePdfExportBuss;
            this.pdfExportSettings = pdfExportOptions?.Value ?? new PdfExportSettings();
        }

        
        [HttpGet]
        [Route("GenerarReporteNom35")]
        public ActionResult GenerarReporteNom35(int idEstudio)
        {
            if (idEstudio <= 0)
            {
                return BadRequest("El id del estudio es inválido.");
            }

            var datosReporteGuiaII = reporteGuiaII.GetReporteGuiaII(idEstudio);

            if (!datosReporteGuiaII.IsSuccesfull || datosReporteGuiaII.ResponseData == null)
            {
                return BadRequest(datosReporteGuiaII.ErrorDetails ?? "No fue posible generar los datos del reporte NOM35.");
            }

            var contentPath = hostEnvironment.ContentRootPath;
            string pathReporte = Path.Combine(contentPath, "Reportes", "Nom35GuiaII.docx");

            if (!System.IO.File.Exists(pathReporte))
            {
                return BadRequest($"No se encontró la plantilla del reporte en: {pathReporte}");
            }

            byte[] reporteByteArray = ReportesWord.GenerarReporteNom35(datosReporteGuiaII.ResponseData, pathReporte);

            return File(reporteByteArray,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                $"Reporte NOM35.docx");
        }

		[HttpGet]
		[Route("DescargarExcelNom35")]
		public FileContentResult DescargarExcelNom35()
		{
			var contentPath = hostEnvironment.ContentRootPath;
			string pathExcel = Path.Combine(contentPath, "Reportes", "Graficos ESTUDIOS NOM35.xlsx");

			FileContentResult file = File(System.IO.File.ReadAllBytes(pathExcel),
				"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
				"Graficos ESTUDIOS NOM35.xlsx");

			return file;
		}

        [HttpGet]
        [Route("ExportarCuestionariosPdf")]
        public FileContentResult ExportarCuestionariosPdf(int idEstudio)
        {
            if (idEstudio <= 0)
            {
                return null;
            }

            QuestPDF.Settings.License = LicenseType.Community;

            var cuestionarios = questionnairePdfExportBuss.GetQuestionnairesForStudy(idEstudio);
            var resolvedSettings = ResolvePdfSettings();

            using (var zipStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (var cuestionario in cuestionarios)
                    {
                        var document = new QuestionnairePdfDocument(cuestionario, resolvedSettings);
                        var pdfBytes = document.GeneratePdf();
                        var fileName = SanitizeFileName($"Empleado_{cuestionario.EmployeeId}_{cuestionario.EmployeeName}.pdf");

                        var entry = archive.CreateEntry(fileName);
                        using (var entryStream = entry.Open())
                        {
                            entryStream.Write(pdfBytes, 0, pdfBytes.Length);
                        }
                    }
                }

                return File(zipStream.ToArray(), "application/zip", $"Cuestionarios_{idEstudio}.zip");
            }
        }

        private static string SanitizeFileName(string fileName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (var invalidChar in invalidChars)
            {
                fileName = fileName.Replace(invalidChar, '_');
            }

            return fileName;
        }

        private PdfExportSettings ResolvePdfSettings()
        {
            var resolved = new PdfExportSettings
            {
                PageSize = pdfExportSettings.PageSize,
                LogoPath = pdfExportSettings.LogoPath,
                WatermarkText = pdfExportSettings.WatermarkText
            };

            if (!string.IsNullOrWhiteSpace(resolved.LogoPath) && !Path.IsPathRooted(resolved.LogoPath))
            {
                resolved.LogoPath = Path.Combine(hostEnvironment.ContentRootPath, resolved.LogoPath);
            }

            return resolved;
        }
	}
}
