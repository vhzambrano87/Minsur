//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class MS_PRODUCCION
    {
        public int produccion_id { get; set; }
        public Nullable<System.DateTime> fecha_op { get; set; }
        public Nullable<int> turno_id { get; set; }
        public Nullable<double> tm_acum_faja1 { get; set; }
        public Nullable<double> tm_acum_ob { get; set; }
        public Nullable<double> mps_porc { get; set; }
        public Nullable<double> presion_ntg { get; set; }
        public Nullable<double> rpm_main_shaft { get; set; }
        public Nullable<double> amp_chancadora { get; set; }
        public Nullable<double> f_aceite_sup { get; set; }
        public Nullable<double> f_aceite_inf { get; set; }
        public Nullable<double> rpm_apron_feeder { get; set; }
        public Nullable<double> a_apron_feeder { get; set; }
        public Nullable<double> a_faja_uno { get; set; }
        public Nullable<double> a_faja_dos { get; set; }
        public Nullable<double> a_faja_tres { get; set; }
        public string tpm { get; set; }
        public string poligonos { get; set; }
        public string celda { get; set; }
        public Nullable<double> frec_av_a { get; set; }
        public Nullable<double> frec_av_b { get; set; }
        public Nullable<double> frec_av_c { get; set; }
        public Nullable<double> pr_hidra_uno { get; set; }
        public Nullable<double> pr_hidra_dos { get; set; }
        public Nullable<double> tk_verde { get; set; }
        public Nullable<double> tk_rojo { get; set; }
        public Nullable<double> stock_pile { get; set; }
        public Nullable<double> ratio_cal { get; set; }
        public Nullable<double> silo_a { get; set; }
        public Nullable<double> silo_b { get; set; }
        public string observacion { get; set; }
        public Nullable<bool> activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}