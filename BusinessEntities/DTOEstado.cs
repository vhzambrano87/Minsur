using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOEstadoRespuesta
    {
        public DTOEstado DTOEstado { get; set; }
        public List<DTOEstado> DTOListaEstado { get; set; }
    }
    public class DTOEstado
    {
        public int estado_id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public bool tipo_mantenimiento { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}