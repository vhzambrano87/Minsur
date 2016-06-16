using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOParadaRespuesta
    {
        public DTOParada DTOParada { get; set; }
        public List<DTOParada> DTOListaParada { get; set; }
    }
    public class DTOParada
    {
        public int parada_id { get; set; }
        public int area_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int turno_id { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public double duracion { get; set; }
        public int tipo_parada_id { get; set; }
        public int sub_tipo_parada_id { get; set; }
        public int estado_id { get; set; }
        public int serie_id { get; set; }
        public string comentario { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public string area_desc { get; set; }
        public string tipo_parada_desc { get; set; }
        public string sub_tipo_parada_desc { get; set; }
        public string serie_desc { get; set; }
        public string estado_desc { get; set; }
        public string turno_desc { get; set; }
        public string fecha_desc { get; set; }
        public string operario_desc { get; set; }
        public string mes { get; set; }

    }
}