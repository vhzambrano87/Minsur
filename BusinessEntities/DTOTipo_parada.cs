using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOTipo_paradaRespuesta
    {
        public DTOTipo_parada DTOTipo_parada { get; set; }
        public List<DTOTipo_parada> DTOListaTipo_parada { get; set; }
    }
    public class DTOTipo_parada
    {
        public int tipo_parada_id { get; set; }
        public int tipo_parada { get; set; }
        public int sub_tipo_parada { get; set; }
        public string codigo_serie { get; set; }
        public string descripcion_serie { get; set; }
        public int estado_serie { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string tipo_parada_desc { get; set; }
        public string sub_tipo_parada_desc { get; set; }
        public string estado_desc { get; set; }

    }
}