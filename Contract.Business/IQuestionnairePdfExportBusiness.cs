using System.Collections.Generic;
using DTO;

namespace Contract.Business
{
    public interface IQuestionnairePdfExportBusiness
    {
        IList<DTOQuestionnairePdf> GetQuestionnairesForStudy(int idEstudio);
    }
}
