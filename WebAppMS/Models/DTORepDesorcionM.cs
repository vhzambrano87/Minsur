using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTORepDesorcionM
    {
        public int tipo_id { get; set; }
        public int anho { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }

        public string periodo_desde { get; set; }
        public string periodo_hasta { get; set; }
    }
}