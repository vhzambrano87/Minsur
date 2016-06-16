using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOAdsorcionM
    {
        public int adsorcion_id { get; set; }
        
        public Nullable<System.DateTime> fecha { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public int horas { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double au_ing_n1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double au_ing_n2 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double au_sal_n1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double au_sal_n2 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ag_ing_n1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ag_ing_n2 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ag_sal_n1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double ag_sal_n2 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double flujo_ini_1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double flujo_ini_2 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double flujo_fin_1 { get; set; }
        [RegularExpression(@"^[0-9\.]*$", ErrorMessage = "Ingresar un valor numérico")]
        public double flujo_fin_2 { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
        public string fecha_desc { get; set; }
    }
}