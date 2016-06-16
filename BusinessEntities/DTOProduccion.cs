using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOProduccionRespuesta
    {
        public DTOProduccion DTOProduccion { get; set; }
        public List<DTOProduccion> DTOListaProduccion { get; set; }
    }
    public class DTOProduccion
    {
        public int produccion_id { get; set; }
        public DateTime fecha_op { get; set; }
        public int dia_int { get; set; }
        public string dia_desc { get; set; }
        public int mes_int { get; set; }
        public string mes_desc { get; set; }
        public int turno_id { get; set; }
        public string turno_desc { get; set; }
        public string tpm_desc { get; set; }
        public int jefe_guardia_id { get; set; }
        public string jefe_guardia { get; set; }
        public int operario_id { get; set; }
        public string operador_planta_chancado { get; set; }
        public int guardia { get; set; }
        public int viajes_ch { get; set; }
        public double ton_ch_cam { get; set; }
        public double ton_ch_ox { get; set; }
        public double tmh_ch_ox { get; set; }
        public double ton_bal_faja1 { get; set; }
        public double tm_acum_ini_ch { get; set; }
        public double tm_acum_fin_ch { get; set; }
        public double tmh_ch_bal { get; set; }
        public double hrs_op_ch { get; set; }
        public double horas_ch { get; set; }
        public double minutos_ch { get; set; }
        public double hrs_mantto_ch { get; set; }
        public double horas_mantto_ch { get; set; }
        public double minutos_mantto_ch { get; set; }
        public double hrs_operacion_ch { get; set; }
        public double horas_operacion_ch { get; set; }
        public double minutos_operacion_ch { get; set; }
        public double hrs_calendario { get; set; }
        public double perc_d_ch { get; set; }
        public double perc_ud_ch { get; set; }
        public double perc_u_ch { get; set; }

        public int viajes_ob { get; set; }
        public double ton_ob_cam { get; set; }
        public double ton_ob_ox { get; set; }
        public double ton_bal_faja3 { get; set; }
        public double tm_acum_ini_ob { get; set; }
        public double tm_acum_fin_ob { get; set; }
        public double tmh_ob_balanza { get; set; }
        public double hrs_op_ob { get; set; }
        public double horas_op_ob { get; set; }
        public double minutos_op_ob { get; set; }
        public double hrs_mantto_ob { get; set; }
        public double horas_mantto_ob { get; set; }
        public double minutos_mantto_ob { get; set; }
        public double hrs_operacion_ob { get; set; }
        public double horas_operacion_ob { get; set; }
        public double minutos_operacion_ob { get; set; }
        public double hrs_calendario_ob { get; set; }
        public double perc_d_ob { get; set; }
        public double perc_ud_ob { get; set; }
        public double perc_u_ob { get; set; }

        public double tm_acum_faja1 { get; set; }
        public double tm_acum_ob { get; set; }





        public double mps_porc { get; set; }
        public double presion_ntg { get; set; }
        public double rpm_main_shaft { get; set; }
        public double amp_chancadora { get; set; }
        public double f_aceite_sup { get; set; }
        public double f_aceite_inf { get; set; }
        public double rpm_apron_feeder { get; set; }
        public double a_apron_feeder { get; set; }
        public double a_faja_uno { get; set; }
        public double a_faja_dos { get; set; }
        public double a_faja_tres { get; set; }
        public string tpm { get; set; }
        public string poligonos { get; set; }
        public string celda { get; set; }
        public double frec_av_a { get; set; }
        public double frec_av_b { get; set; }
        public double frec_av_c { get; set; }
        public double pr_hidra_uno { get; set; }
        public double pr_hidra_dos { get; set; }
        public double tk_verde { get; set; }
        public double tk_rojo { get; set; }
        public double stock_pile { get; set; }
        public double ratio_cal { get; set; }
        public double silo_a { get; set; }
        public double silo_b { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public bool flag_chancadora { get; set; }
        public bool flag_orebin { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
    }
}