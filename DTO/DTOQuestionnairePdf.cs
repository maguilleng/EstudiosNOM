using System;
using System.Collections.Generic;

namespace DTO
{
    public class DTOQuestionnairePdf
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; } = "Cuestionario";
        public string ClientName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string SurveyName { get; set; }
        public DateTime? CompletedAt { get; set; }
        public List<DTOQuestionnairePdfItem> Items { get; set; } = new List<DTOQuestionnairePdfItem>();
    }
}
