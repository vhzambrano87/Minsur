using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOAguas_operacionesM
    {
        public int agua_op_id { get; set; }
        public DateTime fecha { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        public string turno { get; set; }
        public int tecnico_id { get; set; }
        public double nivel_tk_1 { get; set; }
        public double nivel_tk_2 { get; set; }
        public double nivel_tk_contraincendio { get; set; }
        public double nivel_tk_chancado { get; set; }
        public double nivel_pm_pad { get; set; }
        public double nivel_pm_pls { get; set; }
        public double nivel_tk_botadero { get; set; }
        public double consumo_mina_cat_777 { get; set; }
        public double consumo_mina_riego_vias { get; set; }
        public double consumo_mina_riego_caliza { get; set; }
        public double consumo_geologia { get; set; }
        public double consumo_exploracion { get; set; }
        public double consumo_proy_campamento { get; set; }
        public double consumo_proy_obras { get; set; }
        public double consumo_rrhh_timpure { get; set; }
        public double consumo_rrhh_pucamara { get; set; }
        public double pluviometro_lixiviacion { get; set; }
        public double pluviometro_planta_adr { get; set; }
        public double pluviomento_pozos_agua { get; set; }
        public double bombeo_chancado_niv_inicial { get; set; }
        public double bombeo_chancado_niv_final { get; set; }
        public double totalizador_pozo_1 { get; set; }
        public double totalizador_pozo_2 { get; set; }
        public double totalizador_pozo_3 { get; set; }
        public double totalizador_pozo_4 { get; set; }
        public double totalizador_pozo_5 { get; set; }
        public double totalizador_pozo_6 { get; set; }
        public double totalizador_ingreso_tk_2 { get; set; }
        public double totalizador_make_up_planta { get; set; }
        public double nivel_freatico_pozo_1 { get; set; }
        public double nivel_freatico_pozo_2 { get; set; }
        public double nivel_freatico_pozo_3 { get; set; }
        public double nivel_freatico_pozo_4 { get; set; }
        public double nivel_freatico_pozo_5 { get; set; }
        public double nivel_freatico_pozo_6 { get; set; }
        public double variador_velocidad_pozo_1 { get; set; }
        public double variador_velocidad_pozo_2 { get; set; }
        public double variador_velocidad_pozo_3 { get; set; }
        public double variador_velocidad_pozo_4 { get; set; }
        public double variador_velocidad_pozo_5 { get; set; }
        public double variador_velocidad_pozo_6 { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}