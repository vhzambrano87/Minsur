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
    
    public partial class MS_PROD_ORE_BIN
    {
        public int prod_ore_bin_id { get; set; }
        public int produccion_id { get; set; }
        public Nullable<System.DateTime> fecha_op { get; set; }
        public Nullable<int> turno_id { get; set; }
        public Nullable<int> viajes_ob { get; set; }
        public Nullable<double> ton_ob_cam { get; set; }
        public Nullable<double> ton_ob_ox { get; set; }
        public Nullable<double> ton_bal_faja { get; set; }
        public Nullable<double> tm_acum_ini_ob { get; set; }
        public Nullable<double> tm_acum_fin_ob { get; set; }
        public Nullable<double> tmh_ob_bal { get; set; }
        public Nullable<double> h_op_ob { get; set; }
        public Nullable<double> horas { get; set; }
        public Nullable<double> minutos { get; set; }
        public Nullable<double> h_mantto_ob { get; set; }
        public Nullable<double> horas_mantto { get; set; }
        public Nullable<double> minutos_mantto { get; set; }
        public Nullable<double> h_operacion { get; set; }
        public Nullable<double> horas_operacion { get; set; }
        public Nullable<double> minutos_operacion { get; set; }
        public Nullable<double> h_calendario { get; set; }
        public Nullable<double> porc_d_ob { get; set; }
        public Nullable<double> porc_ud_ob { get; set; }
        public Nullable<double> porc_u_ob { get; set; }
        public Nullable<bool> activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}
