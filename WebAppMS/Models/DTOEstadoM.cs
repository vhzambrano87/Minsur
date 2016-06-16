using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOEstadoM
    {
        public int estado_id { get; set; }
        [Required(ErrorMessage = "Ingrese el código")]
        [StringLength(10)]
        public string codigo { get; set; }
        [Required(ErrorMessage = "Ingrese la descripción")]
        [StringLength(200)]
        public string descripcion { get; set; }
        public bool tipo_mantenimiento { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}