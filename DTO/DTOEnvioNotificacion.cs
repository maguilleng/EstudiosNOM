using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOEnvioNotificacion
    {
        public string TipoNotificacion { get; set; }
        public string Para { get; set; }
        public string Cc { get; set; }
        public string Asunto  { get; set; }
        public string MensajeInicial { get; set; }
        public List<DTOLinks> Links { get; set; }
        public string MensajeFinal { get; set; }

    }
}
