using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOProcesoRespuesta
    {
        public DTOProceso DTOProceso { get; set; }
        public List<DTOProceso> DTOListaProceso { get; set; }
    }
    public class DTOProceso
    {
        public int proceso_id { get; set; }
        public string codigo { get; set; }
        public string anho { get; set; }
        public string mes { get; set; }
        public Nullable<System.DateTime> mcl_fecha_inicio { get; set; }
        public Nullable<System.DateTime> mcl_fecha_fin { get; set; }
        public Nullable<System.DateTime> adr_fecha_inicio { get; set; }
        public Nullable<System.DateTime> adr_fecha_fin { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}