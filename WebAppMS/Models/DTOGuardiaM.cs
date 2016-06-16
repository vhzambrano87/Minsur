using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOGuardiaM
    {
        public int guardia_id { get; set; }
        
        public Nullable<System.DateTime> fecha { get; set; }
        public int turno_id { get; set; }
        [Required(ErrorMessage = "Ingrese el grupo")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor ingrese un valor numérico entero")]
        public int grupo { get; set; }
        public int jefe_guardia_id { get; set; }
        public int operador_planta_id { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
        public string turno_desc { get; set; }
        public string jefe_guardia_desc { get; set; }
        public string operador_planta_desc { get; set; }
        public string fecha_desc { get; set; }
    }
}