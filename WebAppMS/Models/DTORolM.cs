using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;

namespace WebAppMS.Models
{
    public class DTORolM
    {
        public int rol_id { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
        public List<DTOUsuario> listaUsuario { get; set; }
        public List<DTOOpcion> listaOpcion { get; set; }
        public string asociados { get; set; }
        public string asociadosOpc { get; set; }
    }
}