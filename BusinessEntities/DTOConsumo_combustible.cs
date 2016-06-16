using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOConsumo_combustibleRespuesta
    {
        public DTOConsumo_combustible DTOConsumo_combustible { get; set; }
        public List<DTOConsumo_combustible> DTOListaConsumo_combustible { get; set; }
    }
    public class DTOConsumo_combustible
    {
        public int consumo_combustible_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int guardia_id { get; set; }
        public int turno_id { get; set; }
        public int equipo_id { get; set; }
        public double galones { get; set; }
        public int operador_id { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string guardia_desc { get; set; }
        public string turno_desc { get; set; }
        public string equipo_desc { get; set; }
        public string operador_desc { get; set; }
    }
}
