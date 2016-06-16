using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOOpcionRespuesta
    {
        public DTOOpcion DTOOpcion { get; set; }
        public List<DTOOpcion> DTOListaOpcion { get; set; }
    }
    public class DTOOpcion
    {
        public int opcion_id { get; set; }
        public string opcion_cod { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public bool asociar { get; set; }
        public string asociados { get; set; }
    }
}