namespace DTO
{
    public class DTOQuestionnairePdfItem
    {
        public string Section { get; set; }
        /// <summary>Norma from NOM_APARTADOS; used to build Encuesta header (Norma - Titulo).</summary>
        public string SectionNorma { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
