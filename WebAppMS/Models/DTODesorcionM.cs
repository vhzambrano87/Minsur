using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTODesorcionM
    {
        public int desorcion_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string num_fundicion { get; set; }
        public string mes { get; set; }
        public int num_desorcion { get; set; }
        public int num_desorcion_mes { get; set; }
        public int num_col_desc { get; set; }
        public double peso_col_desc { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public double au_rico { get; set; }
        public double au_pobre { get; set; }
        public double ag_rico { get; set; }
        public double ag_pobre { get; set; }
        public double hg_rico { get; set; }
        public double hg_pobre { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
        public string fecha_desc { get; set; }
        public string hora_hora_ini { get; set; }
        public string hora_hora_fin { get; set; }
        public string hora_min_ini { get; set; }
        public string hora_min_fin { get; set; }

    }
}