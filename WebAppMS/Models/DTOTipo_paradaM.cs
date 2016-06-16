using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOTipo_paradaM
    {
        public int tipo_parada_id { get; set; }
        [Required(ErrorMessage = "Ingrese el tipo de parada")]
        public int tipo_parada { get; set; }
        [Required(ErrorMessage = "Ingrese el sub tipo de parada")]
        public int sub_tipo_parada { get; set; }
        [Required(ErrorMessage = "Ingrese el código de serie")]
        [StringLength(50)]
        public string codigo_serie { get; set; }
        [Required(ErrorMessage = "Ingrese descripción de serie")]
        [StringLength(500)]
        public string descripcion_serie { get; set; }
        public int estado_serie { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
        public string tipo_parada_desc { get; set; }
        public string sub_tipo_parada_desc { get; set; }
        public string estado_desc { get; set; }
    }
}