using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Regione
    {
        public Regione()
        {
            EvMuscoloesqueleticos = new HashSet<EvMuscoloesqueletico>();
        }

        public int Idregion { get; set; }
        public string Descripcion { get; set; }
        public string Agrupacion { get; set; }

        public virtual ICollection<EvMuscoloesqueletico> EvMuscoloesqueleticos { get; set; }
    }
}
