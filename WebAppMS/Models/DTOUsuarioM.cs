using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOUsuarioM
    {
        public int usuario_id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string newpassword { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
        public int resultado { get; set; }
    }
}