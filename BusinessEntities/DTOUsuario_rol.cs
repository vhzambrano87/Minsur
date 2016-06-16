using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOUsuario_rolRespuesta
    {
        public DTOUsuario_rol DTOUsuario_rol { get; set; }
        public List<DTOUsuario_rol> DTOListaUsuario_rol { get; set; }
    }
    public class DTOUsuario_rol
    {
        public int usuario_id { get; set; }
        public int rol_id { get; set; }
    }
}