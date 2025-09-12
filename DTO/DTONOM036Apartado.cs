using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTONOM036Apartado
    {
        public int? IDApartado { get; set; }
        public int? Indice { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public List<DTONOM036Preguntas> Preguntas { get; set; }
    }
}
