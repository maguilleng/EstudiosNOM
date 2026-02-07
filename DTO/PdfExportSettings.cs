namespace DTO
{
    public class PdfExportSettings
    {
        public string PageSize { get; set; } = "A4";
        public string LogoPath { get; set; }
        public string WatermarkText { get; set; }
    }
}
