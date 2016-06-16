using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOTurno_lixRespuesta
    {
        public DTOTurno_lix DTOTurno_lix { get; set; }
        public List<DTOTurno_lix> DTOListaTurno_lix { get; set; }
    }
    public class DTOTurno_lix
    {
        public int turno_lix_id { get; set; }
        public DateTime fecha { get; set; }
        public string turno { get; set; }
        public int turno_id { get; set; }
        public double poza_pls { get; set; }
        public double lluvia { get; set; }
        public double ley_oro_m1_tren_1 { get; set; }
        public double ley_oro_m1_tren_2 { get; set; }
        public double ley_oro_m2_tren_1 { get; set; }
        public double ley_oro_m2_tren_2 { get; set; }
        public double ley_oro_m3 { get; set; }
        public double ley_plata_m1_tren_1 { get; set; }
        public double ley_plata_m1_tren_2 { get; set; }
        public double ley_plata_m2_tren_1 { get; set; }
        public double ley_plata_m2_tren_2 { get; set; }
        public double flujo_adr_tren_1 { get; set; }
        public double flujo_adr_tren_2 { get; set; }
        public double flujo_lixiviacion { get; set; }
        public double factor { get; set; }
        public double flujo_adr_tren_1_calc { get; set; }
        public double flujo_adr_tren_2_calc { get; set; }
        public double flujo_lixiviacion_calc { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}