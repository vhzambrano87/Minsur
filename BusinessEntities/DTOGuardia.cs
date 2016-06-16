using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOGuardiaRespuesta
    {
        public DTOGuardia DTOGuardia { get; set; }
        public List<DTOGuardia> DTOListaGuardia { get; set; }
    }
    public class DTOGuardia
    {
        public int guardia_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int turno_id { get; set; }
        public int grupo { get; set; }
        public int jefe_guardia_id { get; set; }
        public int operador_planta_id { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public string turno_desc { get; set; }
        public string jefe_guardia_desc { get; set; }
        public string operador_planta_desc { get; set; }
    }
}