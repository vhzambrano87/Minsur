using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTODesorcionRespuesta
    {
        public DTODesorcion DTODesorcion { get; set; }
        public List<DTODesorcion> DTOListaDesorcion { get; set; }
    }
    public class DTODesorcion
    {
        public int desorcion_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public string tiempo_desorcion { get; set; }
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
    }
}