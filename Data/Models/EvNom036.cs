using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class EvNom036
    {
        public EvNom036()
        {
            Nom036Resultados = new HashSet<NomResultado>();
        }

        public int Transid { get; set; }
        public int? Idempleado { get; set; }

        public virtual ICollection<NomResultado> Nom036Resultados { get; set; }
    }
}
