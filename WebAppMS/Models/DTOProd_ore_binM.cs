using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOProd_ore_binM
    {
        public int prod_ore_bin_id { get; set; }
        public int produccion_id { get; set; }
        public DateTime fecha_op { get; set; }
        public string fecha_desc { get; set; }
        public int turno_id { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public int viajes_ob { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ton_ob_cam { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ton_ob_ox { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ton_bal_faja { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double tm_acum_ini_ob { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double tm_acum_fin_ob { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double tmh_ob_bal { get; set; }

        public double h_op_ob { get; set; }
        [RegularExpression(@"^[0-9.,]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double horas { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double minutos { get; set; }

        public double h_mantto_ob { get; set; }
        [RegularExpression(@"^[0-9.,]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double horas_mantto { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double minutos_mantto { get; set; }

        public double h_operacion { get; set; }
        [RegularExpression(@"^[0-9.,]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double horas_operacion { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double minutos_operacion { get; set; }
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double h_calendario { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double porc_d_ob { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double porc_ud_ob { get; set; }
        [Range(0, 100, ErrorMessage = "Ingresar un valor numérico dentro del rango 0-100.")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double porc_u_ob { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }

        public string tmh_ob_ox_desc { get; set; }
        public string ton_bal_faja_desc { get; set; }
        public string tmh_ob_bal_desc { get; set; }

        public string h_op_ob_desc { get; set; }
        public string h_mantto_ob_desc { get; set; }
        public string h_operacion_desc{ get; set; }
    }
}