using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOApilamientoM
    {
        public int apilamiento_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        public string turno { get; set; }
        public double tmh_mineral { get; set; }
        public double ley_au_mineral { get; set; }
        public double ley_ag_mineral { get; set; }
        public double tmh_rom { get; set; }
        public double ley_au_rom { get; set; }
        public double ley_ag_rom { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public double ph { get; set; }
        public double humedad { get; set; }
        public double ley_prom_au { get; set; }
        public double ley_prom_ag { get; set; }
        public double onzas_au { get; set; }
        public double onzas_ag { get; set; }
        public double densidad { get; set; }
        public double volumen { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}