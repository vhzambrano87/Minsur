using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOChancadoraRespuesta
    {
        public DTOChancadora DTOChancadora { get; set; }
        public List<DTOChancadora> DTOListaChancadora { get; set; }
    }
    public class DTOChancadora
    {
        public int chancadora_id { get; set; }
        public DateTime? fecha { get; set; }
        public int guardia_id { get; set; }
        public int turno_id { get; set; }
        public int ch_ore_bin_id { get; set; }
        public int tipo_actividad_id { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public string comentarios { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string guardia_desc { get; set; }
        public string turno_desc { get; set; }
        public string ch_ore_bin_desc { get; set; }
        public string tipo_actividad_desc { get; set; }
    }
}