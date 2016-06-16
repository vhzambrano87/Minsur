using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOCamionesM
    {
        public int camion_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        public int tipo_equipo_id { get; set; }
        public string turno { get; set; }
        public string tipo_equipo { get; set; }
        public double horas_maquina { get; set; }
        public string detalle { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}