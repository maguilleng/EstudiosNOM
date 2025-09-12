using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using WordText = DocumentFormat.OpenXml.Wordprocessing.Text;
using WordTable = DocumentFormat.OpenXml.Wordprocessing.Table;
using WordRun = DocumentFormat.OpenXml.Wordprocessing.Run;
using Data.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ESTUDIOS.OpenXML
{
    public static class ReportesWord
    {
        public static byte[] GenerarReporteNom35(DTOReporteNom35GuiaII DtoReporte, string pathReporte)
        {
            byte[] reporteByteArray;
            MemoryStream reporteStream = new MemoryStream();
            using WordprocessingDocument template = WordprocessingDocument.Open(pathReporte, false);
            using (WordprocessingDocument reporteNom35 = (WordprocessingDocument)template.Clone(reporteStream, true))
            {
                List<WordTable> tablas = reporteNom35.MainDocumentPart.Document.Body.Elements<WordTable>().ToList();
                WordTable tableListaTrabajadores = reporteNom35.MainDocumentPart.Document.Body.Elements<WordTable>().ElementAt((int)Nom35GuiaIITables.ListaTrabajadores);
                WordTable tableAnalisisResultados = reporteNom35.MainDocumentPart.Document.Body.Elements<WordTable>().ElementAt((int)Nom35GuiaIITables.AnalisisResultados);
                UpdateNom35TableListaTrabajadores(tableListaTrabajadores, DtoReporte.Evaluaciones, DtoReporte.Estudio.Subtitulo);
                UpdateNom35TableAnalisisResultados(tableAnalisisResultados, DtoReporte);

                UpdateEtiquetasGenerales(DtoReporte, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35RangosEdad(DtoReporte.RangosEdad, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35AntiguedadPuesto(DtoReporte.AntiguedadPuesto, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35Jornada(DtoReporte.ResumenJornadaLaboral, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35Escolaridad(DtoReporte.ResumenEscolaridad, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35Conclusiones(DtoReporte, reporteNom35.MainDocumentPart.Document.Body);

                var chartParts = reporteNom35.MainDocumentPart.ChartParts.ToList();
                ChartPart chartPartAcontecimientosTraumaticos = chartParts[(int)Nom35GuiaIICharts.AcontTraumaticosSeveros];
                ChartPart chartPartAmbienteTrabajo = chartParts[(int)Nom35GuiaIICharts.AmbienteTrabajo];
                ChartPart chartPartFactoresPropiosActividad = chartParts[(int)Nom35GuiaIICharts.FactoresPropiosActividad];
                ChartPart chartPartOrgTiempoTrabajo = chartParts[(int)Nom35GuiaIICharts.OrgTiempoTrabajo];
                ChartPart chartPartLiderazgoRelaciones = chartParts[(int)Nom35GuiaIICharts.LiderazgoRelaciones];
                ChartPart chartPartCalificacionFinal = chartParts[(int)Nom35GuiaIICharts.CalificacionFinal];


                UpdateNom35ChartAcontecimientosTraumaticos(chartPartAcontecimientosTraumaticos, DtoReporte.CatAcontecimientosTraumaticosData);
                UpdateNom35PieChart(chartPartAmbienteTrabajo, DtoReporte.CatAmbienteTrabajoData);
                UpdateNom35PieChart(chartPartFactoresPropiosActividad, DtoReporte.CatFactoresPropiosActividadData);
                UpdateNom35PieChart(chartPartOrgTiempoTrabajo, DtoReporte.CatOrgTiempoTrabajo);
                UpdateNom35PieChart(chartPartLiderazgoRelaciones, DtoReporte.CatLiderazgoRelacionesData);
                UpdateNom35PieChart(chartPartCalificacionFinal, DtoReporte.CatCalificacionFinalData);

                UpdateNom35AcontTraumaticosProsa(DtoReporte.CatAcontecimientosTraumaticosData, reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35CategoriaProsa(DtoReporte.CatAmbienteTrabajoData, Constants.Nom35CategoriaAmbienteTrabajo,
                    reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35CategoriaProsa(DtoReporte.CatFactoresPropiosActividadData, Constants.Nom35CategoriaFactoresPropiosActividad,
                    reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35CategoriaProsa(DtoReporte.CatOrgTiempoTrabajo, Constants.Nom35CategoriaOrgTiempoTrabajo,
                    reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35CategoriaProsa(DtoReporte.CatLiderazgoRelacionesData, Constants.Nom35CategoriaLiderazgoRelaciones,
                    reporteNom35.MainDocumentPart.Document.Body);
                UpdateNom35CategoriaProsa(DtoReporte.CatCalificacionFinalData, Constants.Nom35CategoriaCalificacionFinal,
                    reporteNom35.MainDocumentPart.Document.Body);

                UpdateHeader(reporteNom35.MainDocumentPart, DtoReporte.EmpresaEvaluada);

                reporteNom35.Save();
                reporteNom35.Close();
                reporteByteArray = reporteStream.ToArray();
            }

            return reporteByteArray;
        }

        private static void UpdateNom35PieChart(ChartPart chartPart, DTONom35CategoryDomain pieChartData)
        {
            Stream wbStream = chartPart.EmbeddedPackagePart.GetStream();
            ReportesExcel.UpdateNom35PieChart(wbStream, pieChartData);

            Chart chart = chartPart.ChartSpace.Descendants<Chart>().FirstOrDefault();
            DoughnutChart doughnutChart = chart.Descendants<DoughnutChart>().FirstOrDefault();
            PieChartSeries pieSerie = doughnutChart.Descendants<PieChartSeries>().FirstOrDefault();
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieSerie.Descendants<DocumentFormat.OpenXml.Drawing.Charts.Values>().FirstOrDefault();
            NumberingCache nc = values.Descendants<NumberingCache>().First();
            IEnumerable<NumericPoint> numericPoints = nc.Elements<NumericPoint>();

            NumericValue nvNulo = numericPoints.ElementAt(0).Elements<NumericValue>().FirstOrDefault();
            NumericValue nvBajo = numericPoints.ElementAt(1).Elements<NumericValue>().FirstOrDefault();
            NumericValue nvMedio = numericPoints.ElementAt(2).Elements<NumericValue>().FirstOrDefault();
            NumericValue nvAlto = numericPoints.ElementAt(3).Elements<NumericValue>().FirstOrDefault();
            NumericValue nvMuyAlto = numericPoints.ElementAt(4).Elements<NumericValue>().FirstOrDefault();

            nvNulo.Text = pieChartData.NuloPorcentaje.ToString();
            nvBajo.Text = pieChartData.BajoPorcentaje.ToString();
            nvMedio.Text = pieChartData.MedioPorcentaje.ToString();
            nvAlto.Text = pieChartData.AltoPorcentaje.ToString();
            nvMuyAlto.Text = pieChartData.MuyAltoPorcentaje.ToString();
        }

        private static void UpdateNom35ChartAcontecimientosTraumaticos(ChartPart chartPart, DTOAcontecimientosTraumaticos acontTraumaticosData)
        {
            Stream wbStream = chartPart.EmbeddedPackagePart.GetStream();
            ReportesExcel.UpdateNom35ChartAcontecimientosTraumaticos(wbStream, acontTraumaticosData);

            Chart chart = chartPart.ChartSpace.Descendants<Chart>().FirstOrDefault();
            DoughnutChart doughnutChart = chart.Descendants<DoughnutChart>().FirstOrDefault();
            PieChartSeries pieSerie = doughnutChart.Descendants<PieChartSeries>().FirstOrDefault();
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieSerie.Descendants<DocumentFormat.OpenXml.Drawing.Charts.Values>().FirstOrDefault();
            NumberingCache nc = values.Descendants<NumberingCache>().First();
            IEnumerable<NumericPoint> numericPoints = nc.Elements<NumericPoint>();

            NumericValue nvNoRequiereAtencion = numericPoints.ElementAt(0).Elements<NumericValue>().FirstOrDefault();
            NumericValue nvRequiereAtencion = numericPoints.ElementAt(1).Elements<NumericValue>().FirstOrDefault();


            nvNoRequiereAtencion.Text = acontTraumaticosData.PorcentajeNoRequiereAtencionClinica.ToString("#.#");
            nvRequiereAtencion.Text = acontTraumaticosData.PorcentajeRequiereAtencionClinica.ToString("#.#");
        }

        private static void UpdateNom35TableListaTrabajadores(WordTable tableListaTrabajadores, List<DTOTrabajadoresEvaluados> trabajadores, string instalacion)
        {
            TableRow firstRow = tableListaTrabajadores.Elements<TableRow>().ElementAt(1);
            DTOTrabajadoresEvaluados primerTrabajador = trabajadores[0];
            TableCell cellActivo = firstRow.Elements<TableCell>().ElementAt(0);
            TableCell cellNumPersonas = firstRow.Elements<TableCell>().ElementAt(1);
            TableCell cellCategoria = firstRow.Elements<TableCell>().ElementAt(2);

            UpdateTableCell(cellActivo, instalacion);
            UpdateTableCell(cellNumPersonas, "1");
            UpdateTableCell(cellCategoria, primerTrabajador.PuestoCategoria);

            cellActivo.TableCellProperties.VerticalMerge = new VerticalMerge() { Val = MergedCellValues.Restart};

            for(int i=1; i<trabajadores.Count; i++)
            {
                TableRow newRow = new TableRow();
                TableCell emptyCell = new TableCell();
                TableCell cellNoPersonas = new TableCell();
                TableCell cellCateg = new TableCell();

                UpdateTableCell(emptyCell, "");
                UpdateTableCell(cellNoPersonas, "1");
                UpdateTableCell(cellCateg, trabajadores[i].PuestoCategoria);

                newRow.TableRowProperties = (TableRowProperties)firstRow.TableRowProperties.Clone();
                emptyCell.TableCellProperties = (TableCellProperties)cellActivo.TableCellProperties.Clone();
                emptyCell.Elements<Paragraph>().First().ParagraphProperties = (ParagraphProperties)cellActivo.Elements<Paragraph>().First().ParagraphProperties.Clone();
                cellNoPersonas.TableCellProperties = (TableCellProperties)cellNumPersonas.TableCellProperties.Clone();
                cellNoPersonas.Elements<Paragraph>().First().ParagraphProperties = (ParagraphProperties)cellNumPersonas.Elements<Paragraph>().First().ParagraphProperties.Clone();
                cellCateg.TableCellProperties = (TableCellProperties)cellCategoria.TableCellProperties.Clone();
                cellCateg.Elements<Paragraph>().First().ParagraphProperties = (ParagraphProperties)cellCategoria.Elements<Paragraph>().First().ParagraphProperties.Clone();

                emptyCell.TableCellProperties.VerticalMerge = new VerticalMerge() { Val = MergedCellValues.Continue};
                
                newRow.AppendChild<TableCell>(emptyCell);
                newRow.AppendChild<TableCell>(cellNoPersonas);
                newRow.AppendChild<TableCell>(cellCateg);
                tableListaTrabajadores.AppendChild<TableRow>(newRow);
            }
        }

        private static void UpdateNom35TableAnalisisResultados(WordTable tableAnalisisResultados, DTOReporteNom35GuiaII dtoReporte)
        {
            TableRow rowCondAmbTrab = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowCondAmbTrab);
            TableRow rowCargaTrab = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowCargaTrab);
            TableRow rowFaltaControlTrab = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowFaltaControlTrab);
            TableRow rowJorTrab = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowJorTrab);
            TableRow rowInterTrabFam = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowInterTrabFam);
            TableRow rowLiderazgo = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowLiderazgo);
            TableRow rowRelTrab = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowRelTrab);
            TableRow rowViolencia = tableAnalisisResultados.Elements<TableRow>().ElementAt((int)RptNom35TableAnalisisResultadosEnum.RowViolencia);

            SetAnalisisResultadosRow(rowCondAmbTrab, dtoReporte.DomCondicionesAmbTrabajoData);
            SetAnalisisResultadosRow(rowCargaTrab, dtoReporte.DomCargaTrabajoData);
            SetAnalisisResultadosRow(rowFaltaControlTrab, dtoReporte.DomFaltaControlTrabajoData);
            SetAnalisisResultadosRow(rowJorTrab, dtoReporte.DomJornadaTrabajoData);
            SetAnalisisResultadosRow(rowInterTrabFam, dtoReporte.DomInterferenciaTrabajoFamiliaData);
            SetAnalisisResultadosRow(rowLiderazgo, dtoReporte.DomLiderazgoData);
            SetAnalisisResultadosRow(rowRelTrab, dtoReporte.DomRelacionesTrabajoData);
            SetAnalisisResultadosRow(rowViolencia, dtoReporte.DomViolenciaData);
        }

        private static void SetAnalisisResultadosRow(TableRow row, DTONom35CategoryDomain domain)
        {
            TableCell nulo = row.Elements<TableCell>().ElementAt(1);
            TableCell bajo = row.Elements<TableCell>().ElementAt(2);
            TableCell medio = row.Elements<TableCell>().ElementAt(3);
            TableCell alto = row.Elements<TableCell>().ElementAt(4);
            TableCell muyAlto = row.Elements<TableCell>().ElementAt(5);

            UpdateTableCell(nulo, (domain.NuloPorcentaje / 100).ToString("#.#%"));
            UpdateTableCell(bajo, (domain.BajoPorcentaje / 100).ToString("#.#%"));
            UpdateTableCell(medio, (domain.MedioPorcentaje / 100).ToString("#.#%"));
            UpdateTableCell(alto, (domain.AltoPorcentaje / 100).ToString("#.#%"));
            UpdateTableCell(muyAlto, (domain.MuyAltoPorcentaje / 100).ToString("#.#%"));
        }

        private static void UpdateNom35AcontTraumaticosProsa(DTOAcontecimientosTraumaticos acontecimientosData, Body template)
        {
            WordText noRequiereAtencionPorcentaje = BuscarTextByPlaceholder(template, "@PORCENTAJE_SIN_TRAUMATICOS_SEVEROS");
            WordText noRequiereAtencionCantidad = BuscarTextByPlaceholder(template, "@CANTIDAD_SIN_TRAUMATICOS_SEVEROS");
            WordText requiereAtencionPorcentaje = BuscarTextByPlaceholder(template, "@PORCENTAJE_CON_TRAUMATICOS_SEVEROS");
            WordText requiereAtencionCantidad = BuscarTextByPlaceholder(template, "@CANTIDAD_CON_TRAUMATICOS_SEVEROS");

            noRequiereAtencionPorcentaje.Text = noRequiereAtencionPorcentaje.Text.Replace("@PORCENTAJE_SIN_TRAUMATICOS_SEVEROS",
                (acontecimientosData.PorcentajeNoRequiereAtencionClinica / 100).ToString("#.#%"));
            noRequiereAtencionCantidad.Text = noRequiereAtencionCantidad.Text.Replace("@CANTIDAD_SIN_TRAUMATICOS_SEVEROS",
                acontecimientosData.CantidadNoRequiereAtencionClinica.ToString("#.#"));
            requiereAtencionPorcentaje.Text = requiereAtencionPorcentaje.Text.Replace("@PORCENTAJE_CON_TRAUMATICOS_SEVEROS",
               (acontecimientosData.PorcentajeRequiereAtencionClinica / 100).ToString("#.#%"));
            requiereAtencionCantidad.Text = requiereAtencionCantidad.Text.Replace("@CANTIDAD_CON_TRAUMATICOS_SEVEROS",
                acontecimientosData.CantidadRequiereAtencionClinica.ToString("#.#"));
        }

        private static void UpdateNom35CategoriaProsa(DTONom35CategoryDomain categoryData, string category, Body template)
        {
            WordText porcentajeNulo = BuscarTextByPlaceholder(template, $"@PORC_CATEGORIA_{category}_NULO");
            WordText cantidadNulo = BuscarTextByPlaceholder(template, $"@CANT_CATEGORIA_{category}_NULO");
            WordText porcentajeBajo = BuscarTextByPlaceholder(template, $"@PORC_CATEGORIA_{category}_BAJO");
            WordText cantidadBajo = BuscarTextByPlaceholder(template, $"@CANT_CATEGORIA_{category}_BAJO");
            WordText porcentajeMedio = BuscarTextByPlaceholder(template, $"@PORC_CATEGORIA_{category}_MEDIO");
            WordText cantidadMedio = BuscarTextByPlaceholder(template, $"@CANT_CATEGORIA_{category}_MEDIO");
            WordText porcentajeAlto = BuscarTextByPlaceholder(template, $"@PORC_CATEGORIA_{category}_ALTO");
            WordText cantidadAlto = BuscarTextByPlaceholder(template, $"@CANT_CATEGORIA_{category}_ALTO");
            WordText porcentajeMuyAlto = BuscarTextByPlaceholder(template, $"@PORC_CATEGORIA_{category}_MUY_ALTO");
            WordText cantidadMuyAlto = BuscarTextByPlaceholder(template, $"@CANT_CATEGORIA_{category}_MUY_ALTO");

            porcentajeNulo.Text = porcentajeNulo.Text.Replace($"@PORC_CATEGORIA_{category}_NULO", (categoryData.NuloPorcentaje / 100).ToString("#.#%"));
            cantidadNulo.Text = cantidadNulo.Text.Replace($"@CANT_CATEGORIA_{category}_NULO", categoryData.NuloValue.ToString("#.#"));
            porcentajeBajo.Text = porcentajeBajo.Text.Replace($"@PORC_CATEGORIA_{category}_BAJO", (categoryData.BajoPorcentaje / 100).ToString("#.#%"));
            cantidadBajo.Text = cantidadBajo.Text.Replace($"@CANT_CATEGORIA_{category}_BAJO", categoryData.BajoValue.ToString("#.#"));
            porcentajeMedio.Text = porcentajeMedio.Text.Replace($"@PORC_CATEGORIA_{category}_MEDIO", (categoryData.MedioPorcentaje / 100).ToString("#.#%"));
            cantidadMedio.Text = cantidadMedio.Text.Replace($"@CANT_CATEGORIA_{category}_MEDIO", categoryData.MedioValue.ToString("#.#"));
            porcentajeAlto.Text = porcentajeAlto.Text.Replace($"@PORC_CATEGORIA_{category}_ALTO", (categoryData.AltoPorcentaje / 100).ToString("#.#%"));
            cantidadAlto.Text = cantidadAlto.Text.Replace($"@CANT_CATEGORIA_{category}_ALTO", categoryData.AltoValue.ToString("#.#"));
            porcentajeMuyAlto.Text = porcentajeMuyAlto.Text.Replace($"@PORC_CATEGORIA_{category}_MUY_ALTO", (categoryData.MuyAltoPorcentaje / 100).ToString("#.#%"));
            cantidadMuyAlto.Text = cantidadMuyAlto.Text.Replace($"@CANT_CATEGORIA_{category}_MUY_ALTO", categoryData.MuyAltoValue.ToString("#.#"));
        }

        public static void UpdateEtiquetasGenerales(DTOReporteNom35GuiaII DtoReporte, Body template)
        {
            WordText lblTituloReporte = BuscarTextByPlaceholder(template, Constants.TituloReporte);
            lblTituloReporte.Text = lblTituloReporte.Text.Replace(Constants.TituloReporte, DtoReporte.Estudio.Titulo);

            List<WordText> lblInstalacionEstudio = BuscarPlaceholders(template, Constants.InstalacionEstudio);
            lblInstalacionEstudio.ForEach(label =>
            {
                label.Text = label.Text.Replace(Constants.InstalacionEstudio, DtoReporte.Estudio.Subtitulo);
            });

            List<WordText> lblFecReporteMesAnio = BuscarPlaceholders(template, Constants.FechaReporteMesAnio);
            lblFecReporteMesAnio.ForEach(label =>
            {
                label.Text = label.Text.Replace(Constants.FechaReporteMesAnio, DtoReporte.Estudio.FechaInforme.Value.ToString("MMMM yyyy"));
            });

            List<WordText> lblFecReporteLarga = BuscarPlaceholders(template, Constants.FechaLargaReporte);
            lblFecReporteLarga.ForEach(label =>
            {
                label.Text = label.Text.Replace(Constants.FechaLargaReporte, DtoReporte.Estudio.FechaInforme.Value.ToString("dd 'de' MMMM 'de' yyyy"));
            });

            List<WordText> lblRazonSocial = BuscarPlaceholders(template, Constants.RazonSocial);
            lblRazonSocial.ForEach(label =>
            {
                label.Text = label.Text.Replace(Constants.RazonSocial, DtoReporte.EmpresaEvaluada.RazonSocial);
            });

            List<WordText> lblCantTrabajadores = BuscarPlaceholders(template, Constants.CantidadTrabajadores);
            lblCantTrabajadores.ForEach(label =>
            {
                label.Text = label.Text.Replace(Constants.CantidadTrabajadores, DtoReporte.Evaluaciones.Count.ToString());
            });

            WordText lblPorcFemenino = BuscarTextByPlaceholder(template, Constants.PorcentajeFemenino);
            lblPorcFemenino.Text = lblPorcFemenino.Text.Replace(Constants.PorcentajeFemenino, (DtoReporte.PorcentajeFemeninos / 100).ToString("#.#%"));
            WordText lblPorcMasculino = BuscarTextByPlaceholder(template, Constants.PorcentajeMasculino);
            lblPorcMasculino.Text = lblPorcMasculino.Text.Replace(Constants.PorcentajeMasculino, (DtoReporte.PorcentajeMasculinos / 100).ToString("#.#%"));
        }

        public static void UpdateHeader(MainDocumentPart mainPart, DTOEmpresas empresaEstudio)
        {
            List<HeaderPart> headers = mainPart.HeaderParts.ToList();
            headers.ForEach(h =>
            {
                DocumentFormat.OpenXml.Wordprocessing.Header header = h.Header;
                List<Paragraph> paragraphs = header.Elements<Paragraph>().Where(p => p.Elements<WordRun>().Any()).ToList();
                if (paragraphs != null && paragraphs.Count > 0)
                {
                    Paragraph paragraphRazonSocial = paragraphs.Find(p => p.Elements<WordRun>().First()
                        .Elements<WordText>().Any(wt => wt.Text.Contains(Constants.RazonSocial)));
                    
                    if (paragraphRazonSocial != null)
                    {
                        WordText texto = paragraphRazonSocial.Elements<WordRun>().First().Elements<WordText>().First();
                        texto.Text = texto.Text.Replace(Constants.RazonSocial, empresaEstudio.RazonSocial);
                    }                    
                }                
            });
        }

        private static void UpdateNom35RangosEdad(DTORangosEdad rangosEdad, Body template)
        {
            WordText rangoEdadPorc15_19 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc15_19);
            WordText rangoEdadCant15_19 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant15_19);
            WordText rangoEdadPorc20_24 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc20_24);
            WordText rangoEdadCant20_24 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant20_24);
            WordText rangoEdadPorc25_29 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc25_29);
            WordText rangoEdadCant25_29 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant25_29);
            WordText rangoEdadPorc30_34 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc30_34);
            WordText rangoEdadCant30_34 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant30_34);
            WordText rangoEdadPorc35_39 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc35_39);
            WordText rangoEdadCant35_39 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant35_39);
            WordText rangoEdadPorc40_44 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc40_44);
            WordText rangoEdadCant40_44 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant40_44);
            WordText rangoEdadPorc45_49 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc45_49);
            WordText rangoEdadCant45_49 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant45_49);
            WordText rangoEdadPorc50_54 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc50_54);
            WordText rangoEdadCant50_54 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant50_54);
            WordText rangoEdadPorc55_59 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc55_59);
            WordText rangoEdadCant55_59 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant55_59);
            WordText rangoEdadPorc60_64 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc60_64);
            WordText rangoEdadCant60_64 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant60_64);
            WordText rangoEdadPorc65_69 = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc65_69);
            WordText rangoEdadCant65_69 = BuscarTextByPlaceholder(template, Constants.RangoEdadCant65_69);
            WordText rangoEdadPorc70Mas = BuscarTextByPlaceholder(template, Constants.RangoEdadPorc70_Mas);
            WordText rangoEdadCant70Mas = BuscarTextByPlaceholder(template, Constants.RangoEdadCant70_Mas);

            rangoEdadPorc15_19.Text = rangoEdadPorc15_19.Text.Replace(Constants.RangoEdadPorc15_19,
                (rangosEdad.PorcentajePersonas15_19 / 100).ToString("#.#%"));
            rangoEdadCant15_19.Text = rangoEdadCant15_19.Text.Replace(Constants.RangoEdadCant15_19,
                rangosEdad.CantidadPersonas15_19.ToString("#.#"));
            rangoEdadPorc20_24.Text = rangoEdadPorc20_24.Text.Replace(Constants.RangoEdadPorc20_24,
                (rangosEdad.PorcentajePersonas20_24 / 100).ToString("#.#%"));
            rangoEdadCant20_24.Text = rangoEdadCant20_24.Text.Replace(Constants.RangoEdadCant20_24,
                rangosEdad.CantidadPersonas20_24.ToString("#.#"));
            rangoEdadPorc25_29.Text = rangoEdadPorc25_29.Text.Replace(Constants.RangoEdadPorc25_29,
                (rangosEdad.PorcentajePersonas25_29 / 100).ToString("#.#%"));
            rangoEdadCant25_29.Text = rangoEdadCant25_29.Text.Replace(Constants.RangoEdadCant25_29,
                rangosEdad.CantidadPersonas25_29.ToString("#.#"));
            rangoEdadPorc30_34.Text = rangoEdadPorc30_34.Text.Replace(Constants.RangoEdadPorc30_34,
                (rangosEdad.PorcentajePersonas30_34 / 100).ToString("#.#%"));
            rangoEdadCant30_34.Text = rangoEdadCant30_34.Text.Replace(Constants.RangoEdadCant30_34,
                rangosEdad.CantidadPersonas30_34.ToString("#.#"));
            rangoEdadPorc35_39.Text = rangoEdadPorc35_39.Text.Replace(Constants.RangoEdadPorc35_39,
                (rangosEdad.PorcentajePersonas35_39 / 100).ToString("#.#%"));
            rangoEdadCant35_39.Text = rangoEdadCant35_39.Text.Replace(Constants.RangoEdadCant35_39,
                rangosEdad.CantidadPersonas35_39.ToString("#.#"));
            rangoEdadPorc40_44.Text = rangoEdadPorc40_44.Text.Replace(Constants.RangoEdadPorc40_44,
                (rangosEdad.PorcentajePersonas40_44 / 100).ToString("#.#%"));
            rangoEdadCant40_44.Text = rangoEdadCant40_44.Text.Replace(Constants.RangoEdadCant40_44,
                rangosEdad.CantidadPersonas40_44.ToString("#.#"));
            rangoEdadPorc45_49.Text = rangoEdadPorc45_49.Text.Replace(Constants.RangoEdadPorc45_49,
                (rangosEdad.PorcentajePersonas45_49 / 100).ToString("#.#%"));
            rangoEdadCant45_49.Text = rangoEdadCant45_49.Text.Replace(Constants.RangoEdadCant45_49,
                rangosEdad.CantidadPersonas45_49.ToString("#.#"));
            rangoEdadPorc50_54.Text = rangoEdadPorc50_54.Text.Replace(Constants.RangoEdadPorc50_54,
                (rangosEdad.PorcentajePersonas50_54 / 100).ToString("#.#%"));
            rangoEdadCant50_54.Text = rangoEdadCant50_54.Text.Replace(Constants.RangoEdadCant50_54,
                rangosEdad.CantidadPersonas50_54.ToString("#.#"));
            rangoEdadPorc55_59.Text = rangoEdadPorc55_59.Text.Replace(Constants.RangoEdadPorc55_59,
                (rangosEdad.PorcentajePersonas55_59 / 100).ToString("#.#%"));
            rangoEdadCant55_59.Text = rangoEdadCant55_59.Text.Replace(Constants.RangoEdadCant55_59,
                rangosEdad.CantidadPersonas55_59.ToString("#.#"));
            rangoEdadPorc60_64.Text = rangoEdadPorc60_64.Text.Replace(Constants.RangoEdadPorc60_64,
                (rangosEdad.PorcentajePersonas60_64 / 100).ToString("#.#%"));
            rangoEdadCant60_64.Text = rangoEdadCant60_64.Text.Replace(Constants.RangoEdadCant60_64,
                rangosEdad.CantidadPersonas60_64.ToString("#.#"));
            rangoEdadPorc65_69.Text = rangoEdadPorc65_69.Text.Replace(Constants.RangoEdadPorc65_69,
                (rangosEdad.PorcentajePersonas65_69 / 100).ToString("#.#%"));
            rangoEdadCant65_69.Text = rangoEdadCant65_69.Text.Replace(Constants.RangoEdadCant65_69,
                rangosEdad.CantidadPersonas65_69.ToString("#.#"));
            rangoEdadPorc70Mas.Text = rangoEdadPorc70Mas.Text.Replace(Constants.RangoEdadPorc70_Mas,
                (rangosEdad.PorcentajePersonas70Mas / 100).ToString("#.#%"));
            rangoEdadCant70Mas.Text = rangoEdadCant70Mas.Text.Replace(Constants.RangoEdadCant70_Mas,
                rangosEdad.CantidadPersonas70Mas.ToString("#.#"));
        }

        private static void UpdateNom35AntiguedadPuesto(DTOAntiguedadPuesto antPuesto, Body template)
        {
            WordText antPuestoPorcMenos6M = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_Menos6M);
            WordText antPuestoCantMenos6M = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_Menos6M);
            WordText antPuestoPorc6M1A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_6M_1A);
            WordText antPuestoCant6M1A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_6M_1A);
            WordText antPuestoPorc1A4A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_1A_4A);
            WordText antPuestoCant1A4A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_1A_4A);
            WordText antPuestoPorc5A9A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_5A_9A);
            WordText antPuestoCant5A9A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_5A_9A);
            WordText antPuestoPorc10A14A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_10A_14A);
            WordText antPuestoCant10A14A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_10A_14A);
            WordText antPuestoPorc15A19A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_15A_19A);
            WordText antPuestoCant15A19A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_15A_19A);
            WordText antPuestoPorc20A24A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_20A_24A);
            WordText antPuestoCant20A24A = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_20A_24A);
            WordText antPuestoPorc25Mas = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoPorc_25_Mas);
            WordText antPuestoCant25Mas = BuscarTextByPlaceholder(template, Constants.AntiguedadPuestoCant_25_Mas);

            antPuestoPorcMenos6M.Text = antPuestoPorcMenos6M.Text.Replace(Constants.AntiguedadPuestoPorc_Menos6M,
                (antPuesto.Porcentaje6Meses / 100).ToString("#.#%"));
            antPuestoCantMenos6M.Text = antPuestoCantMenos6M.Text.Replace(Constants.AntiguedadPuestoCant_Menos6M,
                antPuesto.Cantidad6Meses.ToString("#.#"));
            antPuestoPorc6M1A.Text = antPuestoPorc6M1A.Text.Replace(Constants.AntiguedadPuestoPorc_6M_1A,
                (antPuesto.Porcentaje_6M_1A / 100).ToString("#.#%"));
            antPuestoCant6M1A.Text = antPuestoCant6M1A.Text.Replace(Constants.AntiguedadPuestoCant_6M_1A,
                antPuesto.Cantidad_6M_1A.ToString("#.#"));
            antPuestoPorc1A4A.Text = antPuestoPorc1A4A.Text.Replace(Constants.AntiguedadPuestoPorc_1A_4A,
                (antPuesto.Porcentaje_1A_4A / 100).ToString("#.#%"));
            antPuestoCant1A4A.Text = antPuestoCant1A4A.Text.Replace(Constants.AntiguedadPuestoCant_1A_4A,
                antPuesto.Cantidad_1A_4A.ToString("#.#"));
            antPuestoPorc5A9A.Text = antPuestoPorc5A9A.Text.Replace(Constants.AntiguedadPuestoPorc_5A_9A,
                (antPuesto.Porcentaje_5A_9A / 100).ToString("#.#%"));
            antPuestoCant5A9A.Text = antPuestoCant5A9A.Text.Replace(Constants.AntiguedadPuestoCant_5A_9A,
                antPuesto.Cantidad_5A_9A.ToString("#.#"));
            antPuestoPorc10A14A.Text = antPuestoPorc10A14A.Text.Replace(Constants.AntiguedadPuestoPorc_10A_14A,
                (antPuesto.Porcentaje_10A_14A / 100).ToString("#.#%"));
            antPuestoCant10A14A.Text = antPuestoCant10A14A.Text.Replace(Constants.AntiguedadPuestoCant_10A_14A,
                antPuesto.Cantidad_10A_14A.ToString("#.#"));
            antPuestoPorc15A19A.Text = antPuestoPorc15A19A.Text.Replace(Constants.AntiguedadPuestoPorc_15A_19A,
                (antPuesto.Porcentaje_15A_19A / 100).ToString("#.#%"));
            antPuestoCant15A19A.Text = antPuestoCant15A19A.Text.Replace(Constants.AntiguedadPuestoCant_15A_19A,
                antPuesto.Cantidad_15A_19A.ToString("#.#"));
            antPuestoPorc20A24A.Text = antPuestoPorc20A24A.Text.Replace(Constants.AntiguedadPuestoPorc_20A_24A,
                (antPuesto.Porcentaje_20A_24A / 100).ToString("#.#%"));
            antPuestoCant20A24A.Text = antPuestoCant20A24A.Text.Replace(Constants.AntiguedadPuestoCant_20A_24A,
                antPuesto.Cantidad_20A_24A.ToString("#.#"));
            antPuestoPorc25Mas.Text = antPuestoPorc25Mas.Text.Replace(Constants.AntiguedadPuestoPorc_25_Mas,
                (antPuesto.Porcentaje_Mas25A / 100).ToString("#.#%"));
            antPuestoCant25Mas.Text = antPuestoCant25Mas.Text.Replace(Constants.AntiguedadPuestoCant_25_Mas,
                antPuesto.Cantidad_Mas25A.ToString("#.#"));
        }

        private static void UpdateNom35Jornada(DTOResumenJornadaLaboral jornada, Body template)
        {
            WordText jornadaPorcDiurno = BuscarTextByPlaceholder(template, Constants.JornadaLaboralPorcDiurno);
            WordText jornadaCantcDiurno = BuscarTextByPlaceholder(template, Constants.JornadaLaboralCantDiurno);
            WordText jornadaPorcNocturno = BuscarTextByPlaceholder(template, Constants.JornadaLaboralPorcNocturno);
            WordText jornadaCantcNocturno = BuscarTextByPlaceholder(template, Constants.JornadaLaboralCantNocturno);
            WordText jornadaPorcMixto = BuscarTextByPlaceholder(template, Constants.JornadaLaboralPorcMixto);
            WordText jornadaCantcMixto = BuscarTextByPlaceholder(template, Constants.JornadaLaboralCantMixto);

            jornadaPorcDiurno.Text = jornadaPorcDiurno.Text.Replace(Constants.JornadaLaboralPorcDiurno,
                (jornada.PorcentajeDiurno / 100).ToString("#.#%"));
            jornadaCantcDiurno.Text = jornadaCantcDiurno.Text.Replace(Constants.JornadaLaboralCantDiurno,
                jornada.CantidadDiurno.ToString("#.#"));
            jornadaPorcNocturno.Text = jornadaPorcNocturno.Text.Replace(Constants.JornadaLaboralPorcNocturno,
                (jornada.PorcentajeNocturno / 100).ToString("#.#%"));
            jornadaCantcNocturno.Text = jornadaCantcNocturno.Text.Replace(Constants.JornadaLaboralCantNocturno,
                jornada.CantidadNocturno.ToString("#.#"));
            jornadaPorcMixto.Text = jornadaPorcMixto.Text.Replace(Constants.JornadaLaboralPorcMixto,
                (jornada.PorcentajeMixto / 100).ToString("#.#%"));
            jornadaCantcMixto.Text = jornadaCantcMixto.Text.Replace(Constants.JornadaLaboralCantMixto,
                jornada.CantidadMixto.ToString("#.#"));
        }

        private static void UpdateNom35Escolaridad(DTOResumenEscolaridad escolaridad, Body template)
        {
            WordText escPorcSinFormacion = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcSinFormacion);
            WordText escCantSinFormacion = BuscarTextByPlaceholder(template, Constants.EscolaridadCantSinFormacion);
            WordText escPorcPrimaria = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcPrimaria);
            WordText escCantPrimaria = BuscarTextByPlaceholder(template, Constants.EscolaridadCantPrimaria);
            WordText escPorcSecundaria = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcSecundaria);
            WordText escCantSecundaria = BuscarTextByPlaceholder(template, Constants.EscolaridadCantSecundaria);
            WordText escPorcPreparatoria = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcPreparatoria);
            WordText escCantPreparatoria = BuscarTextByPlaceholder(template, Constants.EscolaridadCantPreparatoria);
            WordText escPorcTecnico = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcTecnico);
            WordText escCantTecnico = BuscarTextByPlaceholder(template, Constants.EscolaridadCantTecnico);
            WordText escPorcLicenciatura = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcLicenciatura);
            WordText escCantLicenciatura = BuscarTextByPlaceholder(template, Constants.EscolaridadCantLicenciatura);
            WordText escPorcMaestria = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcMaestria);
            WordText escCantMaestria = BuscarTextByPlaceholder(template, Constants.EscolaridadCantMaestria);
            WordText escPorcDoctorado = BuscarTextByPlaceholder(template, Constants.EscolaridadPorcDoctorado);
            WordText escCantDoctorado = BuscarTextByPlaceholder(template, Constants.EscolaridadCantDoctorado);

            escPorcSinFormacion.Text = escPorcSinFormacion.Text.Replace(Constants.EscolaridadPorcSinFormacion,
                (escolaridad.PorcentajeSinFormacion / 100).ToString("#.#%"));
            escCantSinFormacion.Text = escCantSinFormacion.Text.Replace(Constants.EscolaridadCantSinFormacion,
                escolaridad.CantidadSinFormacion.ToString("#.#"));
            escPorcPrimaria.Text = escPorcPrimaria.Text.Replace(Constants.EscolaridadPorcPrimaria,
                (escolaridad.PorcentajePrimaria / 100).ToString("#.#%"));
            escCantPrimaria.Text = escCantPrimaria.Text.Replace(Constants.EscolaridadCantPrimaria,
                escolaridad.CantidadPrimaria.ToString("#.#"));
            escPorcSecundaria.Text = escPorcSecundaria.Text.Replace(Constants.EscolaridadPorcSecundaria,
                (escolaridad.PorcentajeSecundaria / 100).ToString("#.#%"));
            escCantSecundaria.Text = escCantSecundaria.Text.Replace(Constants.EscolaridadCantSecundaria,
                escolaridad.CantidadSecundaria.ToString("#.#"));
            escPorcPreparatoria.Text = escPorcPreparatoria.Text.Replace(Constants.EscolaridadPorcPreparatoria,
                (escolaridad.PorcentajePreparatoria / 100).ToString("#.#%"));
            escCantPreparatoria.Text = escCantPreparatoria.Text.Replace(Constants.EscolaridadCantPreparatoria,
                escolaridad.CantidadPreparatoria.ToString("#.#"));
            escPorcTecnico.Text = escPorcTecnico.Text.Replace(Constants.EscolaridadPorcTecnico,
                (escolaridad.PorcentajeTecnicoSuperior / 100).ToString("#.#%"));
            escCantTecnico.Text = escCantTecnico.Text.Replace(Constants.EscolaridadCantTecnico,
                escolaridad.CantidadTecnicoSuperior.ToString("#.#"));
            escPorcLicenciatura.Text = escPorcLicenciatura.Text.Replace(Constants.EscolaridadPorcLicenciatura,
                (escolaridad.PorcentajeLicenciatura / 100).ToString("#.#%"));
            escCantLicenciatura.Text = escCantLicenciatura.Text.Replace(Constants.EscolaridadCantLicenciatura,
                escolaridad.CantidadLicenciatura.ToString("#.#"));
            escPorcMaestria.Text = escPorcMaestria.Text.Replace(Constants.EscolaridadPorcMaestria,
                (escolaridad.PorcentajeMaestria / 100).ToString("#.#%"));
            escCantMaestria.Text = escCantMaestria.Text.Replace(Constants.EscolaridadCantMaestria,
                escolaridad.CantidadMaestria.ToString("#.#"));
            escPorcDoctorado.Text = escPorcDoctorado.Text.Replace(Constants.EscolaridadPorcDoctorado,
                (escolaridad.PorcentajeDoctorado / 100).ToString("#.#%"));
            escCantDoctorado.Text = escCantDoctorado.Text.Replace(Constants.EscolaridadCantDoctorado,
                escolaridad.CantidadDoctorado.ToString("#.#"));
        }

        private static void UpdateNom35Conclusiones(DTOReporteNom35GuiaII dtoReporte, Body template)
        {
            Tuple<double, double, string> CatAmbTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.CatAmbienteTrabajoData);
            Tuple<double, double, string> CatFacPropActResult = BuscarCategoriaDominioMasNegativo(dtoReporte.CatFactoresPropiosActividadData);
            Tuple<double, double, string> DomFaltaCtrlTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomFaltaControlTrabajoData);
            Tuple<double, double, string> DomCargaTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomCargaTrabajoData);
            Tuple<double, double, string> CatOrgTiempoTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.CatOrgTiempoTrabajo);
            Tuple<double, double, string> DomJorTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomJornadaTrabajoData);
            Tuple<double, double, string> DomInterTrabFamResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomInterferenciaTrabajoFamiliaData);
            Tuple<double, double, string> CatLiderazgoRelTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.CatLiderazgoRelacionesData);
            Tuple<double, double, string> DomLiderazgoResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomLiderazgoData);
            Tuple<double, double, string> DomRelTrabResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomRelacionesTrabajoData);
            Tuple<double, double, string> DomViolenciaResult = BuscarCategoriaDominioMasNegativo(dtoReporte.DomViolenciaData);

            WordText porcAcTraumSev = BuscarTextByPlaceholder(template, Constants.ConclPorcAconTraumaticosSeveros);
            WordText cantAcTraumSev = BuscarTextByPlaceholder(template, Constants.ConclCantAconTraumaticosSeveros);

            WordText porcCatAmbTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcCatAmbTrab);
            WordText cantCatAmbTrab = BuscarTextByPlaceholder(template, Constants.ConclCantCatAmbTrab);
            WordText descCatAmbTrab = BuscarTextByPlaceholder(template, Constants.ConclDescCatAmbTrab);

            WordText porcCatFacPropAct = BuscarTextByPlaceholder(template, Constants.ConclPorcCatFacPropAct);
            WordText cantCatFacPropAct = BuscarTextByPlaceholder(template, Constants.ConclCantCatFacPropAct);
            WordText descCatFacPropAct = BuscarTextByPlaceholder(template, Constants.ConclDescCatFacPropAct);

            WordText porcDomFaltaCtrlTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcDomFaltaCtrlTrab);
            WordText cantDomFaltaCtrlTrab = BuscarTextByPlaceholder(template, Constants.ConclCantDomFaltaCtrlTrab);
            WordText descDomFaltaCtrlTrab = BuscarTextByPlaceholder(template, Constants.ConclDescDomFaltaCtrlTrab);

            WordText porcDomCargaTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcDomCargaTrab);
            WordText cantDomCargaTrab = BuscarTextByPlaceholder(template, Constants.ConclCantDomCargaTrab);
            WordText descDomCargaTrab = BuscarTextByPlaceholder(template, Constants.ConclDescDomCargaTrab);

            WordText porcCatOrgTiempoTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcCatOrgTiempoTrab);
            WordText cantCatOrgTiempoTrab = BuscarTextByPlaceholder(template, Constants.ConclCantCatOrgTiempoTrab);
            WordText descCatOrgTiempoTrab = BuscarTextByPlaceholder(template, Constants.ConclDescCatOrgTiempoTrab);

            WordText porcDomJorTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcDomJorTrab);
            WordText cantDomJorTrab = BuscarTextByPlaceholder(template, Constants.ConclCantDomJorTrab);
            WordText descDomJorTrab = BuscarTextByPlaceholder(template, Constants.ConclDescDomJorTrab);

            WordText porcDomInterTrabFam = BuscarTextByPlaceholder(template, Constants.ConclPorcDomInterTrabFam);
            WordText cantDomInterTrabFam = BuscarTextByPlaceholder(template, Constants.ConclCantDomInterTrabFam);
            WordText descDomInterTrabFam = BuscarTextByPlaceholder(template, Constants.ConclDescDomInterTrabFam);

            WordText porcCatLiderazgoRelTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcCatLiderazgoRelTrab);
            WordText cantCatLiderazgoRelTrab = BuscarTextByPlaceholder(template, Constants.ConclCantCatLiderazgoRelTrab);
            WordText descCatLiderazgoRelTrab = BuscarTextByPlaceholder(template, Constants.ConclDescCatLiderazgoRelTrab);

            WordText porcDomLiderazgo = BuscarTextByPlaceholder(template, Constants.ConclPorcDomLiderazgo);
            WordText cantDomLiderazgo = BuscarTextByPlaceholder(template, Constants.ConclCantDomLiderazgo);
            WordText descDomLiderazgo = BuscarTextByPlaceholder(template, Constants.ConclDescDomLiderazgo);

            WordText porcDomRelTrab = BuscarTextByPlaceholder(template, Constants.ConclPorcDomRelTrab);
            WordText cantDomRelTrab = BuscarTextByPlaceholder(template, Constants.ConclCantDomRelTrab);
            WordText descDomRelTrab = BuscarTextByPlaceholder(template, Constants.ConclDescDomRelTrab);

            WordText porcDomViolencia = BuscarTextByPlaceholder(template, Constants.ConclPorcDomViolencia);
            WordText cantDomViolencia = BuscarTextByPlaceholder(template, Constants.ConclCantDomViolencia);
            WordText descDomViolencia = BuscarTextByPlaceholder(template, Constants.ConclDescDomViolencia);

            porcAcTraumSev.Text = porcAcTraumSev.Text.Replace(Constants.ConclPorcAconTraumaticosSeveros,
                (dtoReporte.CatAcontecimientosTraumaticosData.PorcentajeRequiereAtencionClinica / 100).ToString("#.#%"));
            cantAcTraumSev.Text = cantAcTraumSev.Text.Replace(Constants.ConclCantAconTraumaticosSeveros,
                dtoReporte.CatAcontecimientosTraumaticosData.CantidadRequiereAtencionClinica.ToString("#.#"));

            porcCatAmbTrab.Text = porcCatAmbTrab.Text.Replace(Constants.ConclPorcCatAmbTrab,
                (CatAmbTrabResult.Item1 / 100).ToString("#.#%"));
            cantCatAmbTrab.Text = cantCatAmbTrab.Text.Replace(Constants.ConclCantCatAmbTrab,
                CatAmbTrabResult.Item2.ToString("#.#"));
            descCatAmbTrab.Text = descCatAmbTrab.Text.Replace(Constants.ConclDescCatAmbTrab,
                CatAmbTrabResult.Item3);

            porcCatFacPropAct.Text = porcCatFacPropAct.Text.Replace(Constants.ConclPorcCatFacPropAct,
                (CatFacPropActResult.Item1 / 100).ToString("#.#%"));
            cantCatFacPropAct.Text = cantCatFacPropAct.Text.Replace(Constants.ConclCantCatFacPropAct,
                CatFacPropActResult.Item2.ToString("#.#"));
            descCatFacPropAct.Text = descCatFacPropAct.Text.Replace(Constants.ConclDescCatFacPropAct,
                CatFacPropActResult.Item3);

            porcDomFaltaCtrlTrab.Text = porcDomFaltaCtrlTrab.Text.Replace(Constants.ConclPorcDomFaltaCtrlTrab,
                (DomFaltaCtrlTrabResult.Item1 / 100).ToString("#.#%"));
            cantDomFaltaCtrlTrab.Text = cantDomFaltaCtrlTrab.Text.Replace(Constants.ConclCantDomFaltaCtrlTrab,
                DomFaltaCtrlTrabResult.Item2.ToString("#.#"));
            descDomFaltaCtrlTrab.Text = descDomFaltaCtrlTrab.Text.Replace(Constants.ConclDescDomFaltaCtrlTrab,
                DomFaltaCtrlTrabResult.Item3);

            porcDomCargaTrab.Text = porcDomCargaTrab.Text.Replace(Constants.ConclPorcDomCargaTrab,
                (DomCargaTrabResult.Item1 / 100).ToString("#.#%"));
            cantDomCargaTrab.Text = cantDomCargaTrab.Text.Replace(Constants.ConclCantDomCargaTrab,
                DomCargaTrabResult.Item2.ToString("#.#"));
            descDomCargaTrab.Text = descDomCargaTrab.Text.Replace(Constants.ConclDescDomCargaTrab,
                DomCargaTrabResult.Item3);

            porcCatOrgTiempoTrab.Text = porcCatOrgTiempoTrab.Text.Replace(Constants.ConclPorcCatOrgTiempoTrab,
                (CatOrgTiempoTrabResult.Item1 / 100).ToString("#.#%"));
            cantCatOrgTiempoTrab.Text = cantCatOrgTiempoTrab.Text.Replace(Constants.ConclCantCatOrgTiempoTrab,
                CatOrgTiempoTrabResult.Item2.ToString("#.#"));
            descCatOrgTiempoTrab.Text = descCatOrgTiempoTrab.Text.Replace(Constants.ConclDescCatOrgTiempoTrab,
                CatOrgTiempoTrabResult.Item3);

            porcDomJorTrab.Text = porcDomJorTrab.Text.Replace(Constants.ConclPorcDomJorTrab,
                (DomJorTrabResult.Item1 / 100).ToString("#.#%"));
            cantDomJorTrab.Text = cantDomJorTrab.Text.Replace(Constants.ConclCantDomJorTrab,
                DomJorTrabResult.Item2.ToString("#.#"));
            descDomJorTrab.Text = descDomJorTrab.Text.Replace(Constants.ConclDescDomJorTrab,
                DomJorTrabResult.Item3);

            porcDomInterTrabFam.Text = porcDomInterTrabFam.Text.Replace(Constants.ConclPorcDomInterTrabFam,
                (DomInterTrabFamResult.Item1 / 100).ToString("#.#%"));
            cantDomInterTrabFam.Text = cantDomInterTrabFam.Text.Replace(Constants.ConclCantDomInterTrabFam,
                DomInterTrabFamResult.Item2.ToString("#.#"));
            descDomInterTrabFam.Text = descDomInterTrabFam.Text.Replace(Constants.ConclDescDomInterTrabFam,
                DomInterTrabFamResult.Item3);

            porcCatLiderazgoRelTrab.Text = porcCatLiderazgoRelTrab.Text.Replace(Constants.ConclPorcCatLiderazgoRelTrab,
                (CatLiderazgoRelTrabResult.Item1 / 100).ToString("#.#%"));
            cantCatLiderazgoRelTrab.Text = cantCatLiderazgoRelTrab.Text.Replace(Constants.ConclCantCatLiderazgoRelTrab,
                CatLiderazgoRelTrabResult.Item2.ToString("#.#"));
            descCatLiderazgoRelTrab.Text = descCatLiderazgoRelTrab.Text.Replace(Constants.ConclDescCatLiderazgoRelTrab,
                CatLiderazgoRelTrabResult.Item3);

            porcDomLiderazgo.Text = porcDomLiderazgo.Text.Replace(Constants.ConclPorcDomLiderazgo,
                (DomLiderazgoResult.Item1 / 100).ToString("#.#%"));
            cantDomLiderazgo.Text = cantDomLiderazgo.Text.Replace(Constants.ConclCantDomLiderazgo,
                DomLiderazgoResult.Item2.ToString("#.#"));
            descDomLiderazgo.Text = descDomLiderazgo.Text.Replace(Constants.ConclDescDomLiderazgo,
                DomLiderazgoResult.Item3);

            porcDomRelTrab.Text = porcDomRelTrab.Text.Replace(Constants.ConclPorcDomRelTrab,
                (DomRelTrabResult.Item1 / 100).ToString("#.#%"));
            cantDomRelTrab.Text = cantDomRelTrab.Text.Replace(Constants.ConclCantDomRelTrab,
                DomRelTrabResult.Item2.ToString("#.#"));
            descDomRelTrab.Text = descDomRelTrab.Text.Replace(Constants.ConclDescDomRelTrab,
                DomRelTrabResult.Item3);

            porcDomViolencia.Text = porcDomViolencia.Text.Replace(Constants.ConclPorcDomViolencia,
                (DomViolenciaResult.Item1 / 100).ToString("#.#%"));
            cantDomViolencia.Text = cantDomViolencia.Text.Replace(Constants.ConclCantDomViolencia,
                DomViolenciaResult.Item2.ToString("#.#"));
            descDomViolencia.Text = descDomViolencia.Text.Replace(Constants.ConclDescDomViolencia,
                DomViolenciaResult.Item3);
        }

        private static Tuple<double, double, string> BuscarCategoriaDominioMasNegativo(DTONom35CategoryDomain catdomItem)
        {
            double porcMayor = catdomItem.NuloPorcentaje;
            double cantMayor = catdomItem.NuloValue;
            string descripcion = "Nulo";

            if (catdomItem.BajoPorcentaje >= porcMayor)
            {
                porcMayor = catdomItem.BajoPorcentaje;
                cantMayor = catdomItem.BajoValue;
                descripcion = "Bajo";
            }

            if (catdomItem.MedioPorcentaje >= porcMayor)
            {
                porcMayor = catdomItem.MedioPorcentaje;
                cantMayor = catdomItem.MedioValue;
                descripcion = "Medio";
            }

            if (catdomItem.AltoPorcentaje >= porcMayor)
            {
                porcMayor = catdomItem.AltoPorcentaje;
                cantMayor = catdomItem.AltoValue;
                descripcion = "Alto";
            }

            if (catdomItem.MuyAltoPorcentaje >= porcMayor)
            {
                porcMayor = catdomItem.MuyAltoPorcentaje;
                cantMayor = catdomItem.MuyAltoValue;
                descripcion = "Muy Alto";
            }

            return new Tuple<double, double, string>(porcMayor, cantMayor, descripcion);
        }
        
        public static void UpdateTableCell(TableCell cell, string cellContent)
        {
            // Find the first paragraph in the table cell.
            Paragraph p = null;
            if (cell.Elements<Paragraph>().Any())
            {
                p = cell.Elements<Paragraph>().First();
            }
            else
            {
                p = new Paragraph();
                cell.AppendChild<Paragraph>(p);
            }

            // Find the first run in the paragraph.
            WordRun r = null;
            if (p.Elements<WordRun>().Any())
            {
                r = p.Elements<WordRun>().First();
            }
            else
            {
                r = new WordRun();
                p.AppendChild<WordRun>(r);
            }

            // Set the text for the run.
            WordText t = null;
            if (r.Elements<WordText>().Any())
            {
                t = r.Elements<WordText>().First();
            }
            else
            {
                t = new WordText();
                r.AppendChild<WordText>(t);
            }

            t.Text = cellContent;
        }


        public static WordText BuscarTextByPlaceholder(OpenXmlElement element, string placeholder)
        {
            WordText text = element.Descendants<WordText>().First(t => t.Text.Contains(placeholder));
            return text;
        }

        public static List<WordText> BuscarPlaceholders(OpenXmlElement element, string placeholder)
        {
            List<WordText> textos = element.Descendants<WordText>().Where(t => t.Text.Contains(placeholder)).ToList();
            return textos;
        }
    }
}
