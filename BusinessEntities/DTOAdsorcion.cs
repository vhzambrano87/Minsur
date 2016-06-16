using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOAdsorcionRespuesta
    {
        public DTOAdsorcion DTOAdsorcion { get; set; }
        public List<DTOAdsorcion> DTOListaAdsorcion { get; set; }
    }
    public class DTOAdsorcion
    {
        public int adsorcion_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public int mes { get; set; }
        public int horas { get; set; }
        public double au_ing_n1 { get; set; }
        public double au_ing_n2 { get; set; }
        public double au_sal_n1 { get; set; }
        public double au_sal_n2 { get; set; }

        public double ag_ing_n1 { get; set; }
        public double ag_ing_n2 { get; set; }
        public double ag_sal_n1 { get; set; }
        public double ag_sal_n2 { get; set; }

        public double flujo_ini_1 { get; set; }
        public double flujo_ini_2 { get; set; }
        public double flujo_fin_1 { get; set; }
        public double flujo_fin_2 { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}