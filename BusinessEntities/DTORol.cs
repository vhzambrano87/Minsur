using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTORolRespuesta
    {
        public DTORol DTORol { get; set; }
        public List<DTORol> DTOListaRol { get; set; }
    }
    public class DTORol
    {
        public int rol_id { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}