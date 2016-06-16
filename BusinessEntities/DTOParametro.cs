using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOParametroRespuesta
    {
        public DTOParametro DTOParametro { get; set; }
        public List<DTOParametro> DTOListaParametro { get; set; }
    }
    public class DTOParametro
    {
        public int parametro_id { get; set; }
        public double horas { get; set; }
        public double total_ini { get; set; }
        public double total_fin { get; set; }
        public double flujo_dia { get; set; }
        public double nivel_poza_pls { get; set; }
        public double nivel_poza_may { get; set; }
        public double vol_poza_pls { get; set; }
        public double vol_poza_may { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}