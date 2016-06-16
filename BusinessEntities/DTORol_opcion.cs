using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTORol_opcionRespuesta
    {
        public DTORol_opcion DTORol_opcion { get; set; }
        public List<DTORol_opcion> DTOListaRol_opcion { get; set; }
    }
    public class DTORol_opcion
    {
        public int rol_id { get; set; }
        public int opcion_id { get; set; }
    }
}