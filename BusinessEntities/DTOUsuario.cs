using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOUsuarioRespuesta
    {
        public DTOUsuario DTOUsuario { get; set; }
        public List<DTOUsuario> DTOListaUsuario { get; set; }
    }
    public class DTOUsuario
    {
        public int usuario_id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public bool asociar { get; set; }
        public string asociados { get; set; }
    }
}