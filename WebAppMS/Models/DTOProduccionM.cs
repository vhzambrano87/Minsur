using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOProduccionM
    {
        public int produccion_id { get; set; }
        public DateTime fecha_op { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        public string turno_desc { get; set; }
        public double tm_acum_faja1 { get; set; }
        public double tm_acum_ob { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
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
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        public double frec_av_a { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        public double frec_av_b { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        public double frec_av_c { get; set; }
        public double pr_hidra_uno { get; set; }
        public double pr_hidra_dos { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        public double tk_verde { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
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
        public int resultado { get; set; }
        public bool flagChancadora { get; set; }
        public bool flagOreBin { get; set; }
    }
}