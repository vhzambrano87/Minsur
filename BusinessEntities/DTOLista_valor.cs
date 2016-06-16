using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOLista_valorRespuesta
    {
        public DTOLista_valor DTOLista_valor { get; set; }
        public List<DTOLista_valor> DTOListaLista_valor { get; set; }
    }
    public class DTOLista_valor
    {
        public int lista_valor_id { get; set; }
        public int lista_id { get; set; }
        public string valor { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public string lista { get; set; }
    }
}