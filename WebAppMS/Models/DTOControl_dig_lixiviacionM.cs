using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOControl_dig_lixiviacionM
    {
        public int control_dig_lix_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        public int celda_id { get; set; }
        public int tecnico_lixiviacion_id { get; set; }
        public int tecnico_apilamiento_id { get; set; }
        public string turno { get; set; }
        public string celda { get; set; }
        public string tecnico_lixiviacion { get; set; }
        public string tecnico_apilamiento { get; set; }
        public int nro_viajes { get; set; }
        public string celda_opc { get; set; }
        public int nro_camiones { get; set; }
        public double ley_mineral { get; set; }
        public double poligono { get; set; }
        public double pluviometro { get; set; }
        public double cal_viva { get; set; }
        public double cal_hidratada { get; set; }
        public double corte { get; set; }
        public double ripeo { get; set; }
        public double totalizador_tk_2 { get; set; }
        public double nivel_tk_2 { get; set; }
        public double presion_flujo { get; set; }
        public string comentarios { get; set; }
        public double flujo { get; set; }
        public double presion_adr { get; set; }
        public double presion_sump { get; set; }
        public double presion_925 { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}