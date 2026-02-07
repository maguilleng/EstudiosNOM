using System.Collections.Generic;
using System.Linq;
using Contract.Business;
using Data.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace Business.Pdf
{
    public class QuestionnairePdfExportBusiness : IQuestionnairePdfExportBusiness
    {
        private readonly ESTUDIOS_NOM35Context context;

        public QuestionnairePdfExportBusiness(ESTUDIOS_NOM35Context context)
        {
            this.context = context;
        }

        public IList<DTOQuestionnairePdf> GetQuestionnairesForStudy(int idEstudio)
        {
            var estudio = context.Estudios
                .Include(e => e.RfcempresaNavigation)
                .Include(e => e.TrabajadoresEstudios)
                .FirstOrDefault(e => e.Idestudio == idEstudio);

            if (estudio == null)
            {
                return new List<DTOQuestionnairePdf>();
            }

            var clientName = estudio.RfcempresaNavigation?.RazonSocial ?? string.Empty;
            var surveyName = estudio.Titulo ?? string.Empty;

            var result = new List<DTOQuestionnairePdf>();

            foreach (var trabajador in estudio.TrabajadoresEstudios)
            {
                var items = (from resultado in context.NomResultados
                             where resultado.Idempleado == trabajador.Idtrabajador
                             join pregunta in context.NomPreguntas on resultado.Idpregunta equals pregunta.Idpregunta
                             join apartado in context.NomApartados on resultado.Idapartado equals apartado.Idapartado
                             join respuesta in context.NomRespuestas on resultado.Idrespuesta equals respuesta.Idrespuesta into respuestaJoin
                             from respuesta in respuestaJoin.DefaultIfEmpty()
                             orderby apartado.Indice, pregunta.Indice
                             select new DTOQuestionnairePdfItem
                             {
                                 Section = apartado.Titulo,
                                 Question = string.IsNullOrWhiteSpace(pregunta.Titulo) ? pregunta.Descripcion : pregunta.Titulo,
                                 Answer = BuildAnswer(respuesta, resultado)
                             }).ToList();

                result.Add(new DTOQuestionnairePdf
                {
                    EmployeeId = trabajador.Idtrabajador,
                    Title = "Cuestionario",
                    ClientName = clientName,
                    EmployeeName = trabajador.Nombre ?? string.Empty,
                    SurveyName = surveyName,
                    CompletedAt = trabajador.FechaEvaluacion,
                    Items = items
                });
            }

            return result;
        }

        private static string BuildAnswer(NomRespuesta respuesta, NomResultado resultado)
        {
            if (respuesta == null && resultado == null)
            {
                return string.Empty;
            }

            var answer = respuesta?.Descripcion ?? string.Empty;

            if (resultado?.PesoCarga != null || resultado?.FrecuenciaHora != null)
            {
                var pesoCarga = resultado.PesoCarga?.ToString() ?? "-";
                var frecuencia = resultado.FrecuenciaHora?.ToString() ?? "-";
                answer = $"{answer} (Peso carga: {pesoCarga}, Frecuencia: {frecuencia})".Trim();
            }

            return answer;
        }
    }
}
