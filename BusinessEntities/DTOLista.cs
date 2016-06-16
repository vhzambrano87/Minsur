using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOListaRespuesta
    {
        public DTOLista DTOLista { get; set; }
        public List<DTOLista> DTOListaLista { get; set; }
    }
    public class DTOLista
    {
        public int lista_id { get; set; }
        public string lista { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}