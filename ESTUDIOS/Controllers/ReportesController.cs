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

        public ReportesController(
            IWebHostEnvironment hostEnvironment,
            ITrabajadoresEvaluadosBusiness trabajadoresEvaBuss,
            IEstudiosBusiness estudiosBuss,
            IReportesBusiness reportbuss)
        {
            this.hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            this.trabajadoresEvaBuss = trabajadoresEvaBuss;
            this.estudiosBuss = estudiosBuss;
            this.reporteGuiaII = reportbuss;
        }

        
        [HttpGet]
        [Route("GenerarReporteNom35")]
        public FileContentResult GenerarReporteNom35(int idEstudio)
        {

            var datosReporteGuiaII = reporteGuiaII.GetReporteGuiaII(idEstudio);
            

            var contentPath = hostEnvironment.ContentRootPath;
            string pathReporte = Path.Combine(contentPath, "Reportes", "Nom35GuiaII.docx");

            if (idEstudio == 0)
            {
                return null;
            }

            DTOReporteNom35GuiaII DtoReporteNom35GuiaII = datosReporteGuiaII.ResponseData;

            byte[] reporteByteArray = ReportesWord.GenerarReporteNom35(DtoReporteNom35GuiaII, pathReporte);

            FileContentResult file = File(reporteByteArray,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                $"Reporte NOM35.docx");

            return file;
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
	}
}
