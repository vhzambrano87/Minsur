using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOIngresonivelespozaRespuesta
    {
        public DTOIngresonivelespoza DTOIngresonivelespoza { get; set; }
        public List<DTOIngresonivelespoza> DTOListaIngresonivelespoza { get; set; }
    }
    public class DTOIngresonivelespoza
    {
        public int ingresonivelespoza_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string turno { get; set; }
        public decimal? cotapls { get; set; }
        public decimal? volumepls { get; set; }
        public decimal? cotapge { get; set; }
        public decimal? volumepge { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}