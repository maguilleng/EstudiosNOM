using System;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using DTO;

namespace Business.Pdf
{
    public class QuestionnairePdfDocument : IDocument
    {
        private readonly DTOQuestionnairePdf data;
        private readonly PdfExportSettings settings;

        public QuestionnairePdfDocument(DTOQuestionnairePdf data, PdfExportSettings settings = null)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.settings = settings ?? new PdfExportSettings();
        }

        public DocumentMetadata GetMetadata()
        {
            return DocumentMetadata.Default;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Size(ResolvePageSize(settings.PageSize));
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Background().Element(ComposeWatermark);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Pagina ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                if (!string.IsNullOrWhiteSpace(settings.LogoPath) && File.Exists(settings.LogoPath))
                {
                    column.Item()
                        .AlignLeft()
                        .Height(40)
                        .Image(settings.LogoPath)
                        .FitWidth();
                }

                column.Item().Text(data.Title).FontSize(16).SemiBold();
                column.Item().Text($"Cliente: {data.ClientName}");
                column.Item().Text($"Empleado: {data.EmployeeName}");
                if (!string.IsNullOrWhiteSpace(data.SurveyName))
                {
                    column.Item().Text($"Encuesta: {data.SurveyName}");
                }

                if (data.CompletedAt.HasValue)
                {
                    column.Item().Text($"Fecha: {data.CompletedAt.Value:yyyy-MM-dd HH:mm}");
                }

                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
            });
        }

        private void ComposeContent(IContainer container)
        {
            if (data.Items == null || data.Items.Count == 0)
            {
                container.Text("Sin respuestas registradas.");
                return;
            }

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);
                    columns.RelativeColumn(4);
                    columns.RelativeColumn(3);
                });

                table.Header(header =>
                {
                    header.Cell().Text("Seccion").SemiBold();
                    header.Cell().Text("Pregunta").SemiBold();
                    header.Cell().Text("Respuesta").SemiBold();
                    header.Cell().ColumnSpan(3).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                });

                foreach (var item in data.Items)
                {
                    table.Cell().Text(item.Section ?? string.Empty);
                    table.Cell().Text(item.Question ?? string.Empty);
                    table.Cell().Text(item.Answer ?? string.Empty);
                }
            });
        }

        private void ComposeWatermark(IContainer container)
        {
            if (string.IsNullOrWhiteSpace(settings.WatermarkText))
            {
                return;
            }

            container
                .AlignCenter()
                .Text(settings.WatermarkText)
                .FontSize(40)
                .FontColor(Colors.Grey.Lighten3);
        }

        private static PageSize ResolvePageSize(string pageSize)
        {
            switch ((pageSize ?? string.Empty).Trim().ToUpperInvariant())
            {
                case "LETTER":
                    return PageSizes.Letter;
                case "LEGAL":
                    return PageSizes.Legal;
                default:
                    return PageSizes.A4;
            }
        }
    }
}
